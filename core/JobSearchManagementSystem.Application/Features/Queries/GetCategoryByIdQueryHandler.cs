using AutoMapper;
using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Interfaces.Commons;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Queries
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryViewDto>
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }

        public async Task<CategoryViewDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoriesRepository.GetByIdAsync(request.Id);
            return _mapper.Map<CategoryViewDto>(categories);
        }
    }
}
