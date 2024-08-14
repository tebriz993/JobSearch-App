using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Mapper;
using JobSearchManagementSystem.Domain.Entities.Account;

public class UserViewDto : IMapTo<User>
{
    public int Id { get; set; }
    public string Email { get; set; }
    public IEnumerable<string> Roles { get; set; }
    public UserDetailViewDto UserDetail { get; set; }

}