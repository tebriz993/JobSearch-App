using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Helper;
using JobSearchManagementSystem.Application.Interfaces;
using JobSearchManagementSystem.Application.Features.Command;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JobSearchManagementSystem.Application.Extensions;
using Microsoft.Extensions.Configuration;

namespace JobSearchManagementSystem.Application.Features.Command
{
    public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, AuthenticatedUserDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _configuration;

        public GenerateTokenCommandHandler(IUnitOfWork uow, IConfiguration configuration)
        {
            _uow = uow;
            _configuration = configuration;
        }

        public async Task<AuthenticatedUserDto> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _uow.UserRepository.GetUserWithDetail(request.Email);

            if (user is null)
            {
                throw new JobSearchException("Email not found!");
            }

            if (!HashHelper.VerifyPasswordHash(request.Password,
                Convert.FromBase64String(user.PasswordHash),
                Convert.FromBase64String(user.PassswordSalt)))
            {
                throw new JobSearchException("Invalid password");
            }

            // Retrieve the JWT secret key from configuration
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Define claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserDetail.FirstName),
                new Claim(ClaimTypes.Surname, user.UserDetail.LastName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            // Create token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticatedUserDto
            {
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
