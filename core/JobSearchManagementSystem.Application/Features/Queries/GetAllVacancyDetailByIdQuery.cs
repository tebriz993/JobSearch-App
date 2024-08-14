using MediatR;
using JobSearchManagementSystem.Application.Dtos;

namespace JobSearchManagementSystem.Application.Features.Queries
{
    public class GetAllVacancyDetailByIdQuery : IRequest<VacancyDetailViewDto>
    {
        public int Id { get; set; }
    }
}
