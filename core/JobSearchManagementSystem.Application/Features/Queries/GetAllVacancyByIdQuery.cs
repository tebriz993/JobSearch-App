using MediatR;
using JobSearchManagementSystem.Application.Dtos;

namespace JobSearchManagementSystem.Application.Features.Queries
{
    public class GetAllVacancyByIdQuery : IRequest<VacancyViewDto>
    {
        public int Id { get; set; }
    }
}
