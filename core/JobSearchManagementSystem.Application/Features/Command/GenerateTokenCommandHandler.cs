using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Extensions;
using JobSearchManagementSystem.Application.Helper;
using JobSearchManagementSystem.Application.Interfaces;
using JobSearchManagementSystem.Application.Features.Command;
using MediatR;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace CarRental.Application.Features.Command
{
    public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, AuthenticatedUserDto>
    {
        private readonly IUnitOfWork _uow;

        public GenerateTokenCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public async Task<AuthenticatedUserDto> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
        {


            var user = await _uow.UserRepository.GetUserWithDetail(request.Email);

            if (user is null && HashHelper.VerifyPasswordHash(request.Password, Convert.FromBase64String(user.PasswordHash), Convert.FromBase64String(user.PassswordSalt)))
            {
                throw new JobSearchException("Email or password is incorrect");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name , user.UserDetail.FirstName),
                new Claim(ClaimTypes.Surname , user.UserDetail.LastName),
            };
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