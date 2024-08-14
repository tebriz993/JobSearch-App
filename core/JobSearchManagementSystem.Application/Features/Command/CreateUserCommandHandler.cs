using AutoMapper;
using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Features.Command;
using JobSearchManagementSystem.Application.Helper;
using JobSearchManagementSystem.Application.Interfaces;
using JobSearchManagementSystem.Domain.Entities.Account;
using MediatR;
using System.Diagnostics;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, AuthenticatedUserDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    public CreateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IMediator mediator)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }

    public async Task<AuthenticatedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        user.UserDetail = _mapper.Map<UserDetail>(request);

        byte[] passwordHash, passwordSalt;
        HashHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
        user.PasswordHash = Convert.ToBase64String(passwordHash);
        user.PassswordSalt = Convert.ToBase64String(passwordSalt);

        user.UserRoles.Add(new UserRole
        {
            RoleId = 10
        });

        // Add user to context
        await _unitOfWork.UserRepository.AddUser(user);

        // Log user state before committing
        Debug.WriteLine($"User state before commit: Id={user.Id}, Email={user.Email}");

        // Commit transaction
        await _unitOfWork.Commit(cancellationToken);
        await _unitOfWork.CommitTransaction();

        // Log user state after commit
        Debug.WriteLine($"User state after commit: Id={user.Id}, Email={user.Email}");

        // Query user to check if it was saved
        var savedUser = await _unitOfWork.UserRepository.GetUserWithDetail(request.Email);
        Debug.WriteLine(savedUser == null ? "User not found after commit." : $"User found: Id={savedUser.Id}, Email={savedUser.Email}");

        return await _mediator.Send(new GenerateTokenCommand
        {
            Email = request.Email,
            Password = request.Password
        }, cancellationToken);
    }

}
