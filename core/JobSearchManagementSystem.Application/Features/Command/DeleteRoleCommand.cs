using MediatR;

namespace JobSearchManagementSystem.Application.Features.Command
{
    public class DeleteRoleCommand : IRequest
    {
        public int Id { get; set; }
    }
}
