using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Mapper;
using JobSearchManagementSystem.Domain.Entities.Account;
using MediatR;

namespace JobSearchManagementSystem.Application.Features.Command
{
    public class CreateUserCommand : IMapTo<User>, IMapTo<UserDetail>, IRequest<AuthenticatedUserDto>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}