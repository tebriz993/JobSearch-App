using MediatR;

namespace JobSearchManagementSystem.Application.Features.Command
{
    public class DeleteVacancyDetailCommand : IRequest
    {
        public int Id { get; set; }
    }
}
