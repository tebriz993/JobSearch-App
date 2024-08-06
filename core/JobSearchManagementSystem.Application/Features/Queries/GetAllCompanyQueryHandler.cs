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
    public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQuery, IEnumerable<CompanyViewDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllCompanyQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyViewDto>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            var companies = await _uow.CompaniesRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CompanyViewDto>>(companies);
        }
    }
}
