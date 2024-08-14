using AutoMapper;
using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Queries
{
    public class GetAllVacancyQueryHandler : IRequestHandler<GetAllVacancyQuery, IEnumerable<VacancyViewDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllVacancyQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VacancyViewDto>> Handle(GetAllVacancyQuery request, CancellationToken cancellationToken)
        {
            var vacancies = await _uow.VacanciesRepository.GetAllVacancies();
            return _mapper.Map<IEnumerable<VacancyViewDto>>(vacancies);
        }
    }
}
