using AutoMapper;
using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Features.Command;
using JobSearchManagementSystem.Application.Helper;
using JobSearchManagementSystem.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, AuthenticatedUserDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UpdateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<AuthenticatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the UserId from the claims in the HttpContext
        var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdClaim == null || !int.TryParse(userIdClaim, out var userId))
        {
            throw new Exception("User not authenticated");
        }

        var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        // Update user details
        user.Email = request.Email;
        user.UserDetail.FirstName = request.FirstName;
        user.UserDetail.LastName = request.LastName;
        user.UserDetail.Address = request.Address;

        if (request.Password != null)
        {
            byte[] passwordHash, passwordSalt;
            HashHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            user.PasswordHash = Convert.ToBase64String(passwordHash);
            user.PassswordSalt = Convert.ToBase64String(passwordSalt);
        }

        if (request.ProfilePicture != null)
        {
            var filename = Guid.NewGuid().ToString() + Path.GetExtension(request.ProfilePicture.FileName);
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "assets", "img");
            var filePath = Path.Combine(uploadsFolder, filename);

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.ProfilePicture.CopyToAsync(stream);
            }

            user.UserDetail.ProfilePicture = $"/assets/img/{filename}";
        }

        await _unitOfWork.UserRepository.UpdateUser(user);
        await _unitOfWork.Commit();

        return await _mediator.Send(new GenerateTokenCommand
        {
            Email = request.Email,
            Password = request.Password
        });
    }
}
