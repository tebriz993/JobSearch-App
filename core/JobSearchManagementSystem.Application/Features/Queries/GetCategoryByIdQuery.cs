using MediatR;
using JobSearchManagementSystem.Application.Dtos;

namespace JobSearchManagementSystem.Application.Features.Queries
{
    public class GetCategoryByIdQuery : IRequest<CategoryViewDto>
    {
        public int Id { get; set; }
    }
}
