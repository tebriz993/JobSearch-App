using MediatR;
using JobSearchManagementSystem.Application.Dtos;

namespace JobSearchManagementSystem.Application.Features.Queries
{
    public class GetCompanyByIdQuery : IRequest<CompanyViewDto>
    {
        public int Id { get; set; }
    }
}
