using AutoMapper;
using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Queries
{
    public class GetAllVacancyDetailQueryHandler : IRequestHandler<GetAllVacancyDetailQuery, IEnumerable<VacancyDetailViewDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllVacancyDetailQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VacancyDetailViewDto>> Handle(GetAllVacancyDetailQuery request, CancellationToken cancellationToken)
        {
            var vacancyDetails = await _uow.VacancyDetailRepository.GetAllVacancyDetails();
            return _mapper.Map<IEnumerable<VacancyDetailViewDto>>(vacancyDetails);
        }
    }
}
