using AutoMapper;
using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Interfaces.Commons;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Queries
{
    public class GetAllVacancyByIdQueryHandler : IRequestHandler<GetAllVacancyByIdQuery, VacancyViewDto>
    {
        private readonly IVacanciesRepository _vacanciesRepository;
        private readonly IMapper _mapper;

        public GetAllVacancyByIdQueryHandler(IVacanciesRepository vacanciesRepository, IMapper mapper)
        {
            _vacanciesRepository = vacanciesRepository;
            _mapper = mapper;
        }

        public async Task<VacancyViewDto> Handle(GetAllVacancyByIdQuery request, CancellationToken cancellationToken)
        {
            var vacancies = await _vacanciesRepository.GetByIdAsync(request.Id);
            return _mapper.Map<VacancyViewDto>(vacancies);
        }
    }
}
