using AutoMapper;
using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Queries
{
    public class GetAllCategoriesQueryHandler: IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryViewDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryViewDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            
            var categories = await _uow.CategoriesRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryViewDto>>(categories);
        }
    }
}
