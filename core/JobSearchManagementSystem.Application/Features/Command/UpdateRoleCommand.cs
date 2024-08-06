using MediatR;

namespace JobSearchManagementSystem.Application.Features.Command
{
    public class UpdateRoleCommand : IRequest
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
