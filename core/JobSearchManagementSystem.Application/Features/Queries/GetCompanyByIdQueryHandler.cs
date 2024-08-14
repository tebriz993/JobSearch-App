using AutoMapper;
using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Interfaces.Commons;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Queries
{
    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, CompanyViewDto>
    {
        private readonly ICompaniesRepository _companiesRepository;
        private readonly IMapper _mapper;

        public GetCompanyByIdQueryHandler(ICompaniesRepository companiesRepository, IMapper mapper)
        {
            _companiesRepository = companiesRepository;
            _mapper = mapper;
        }

        public async Task<CompanyViewDto> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _companiesRepository.GetByIdAsync(request.Id);
            return _mapper.Map<CompanyViewDto>(company);
        }
    }
}
