using AutoMapper;
using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Interfaces.Commons;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Queries
{
    public class GetAllVacancyDetailByIdQueryHandler : IRequestHandler<GetAllVacancyDetailByIdQuery, VacancyDetailViewDto>
    {
        private readonly IVacancyDetailRepository _vacancyDetailRepository;
        private readonly IMapper _mapper;

        public GetAllVacancyDetailByIdQueryHandler(IVacancyDetailRepository vacancyDetailRepository, IMapper mapper)
        {
            _vacancyDetailRepository = vacancyDetailRepository;
            _mapper = mapper;
        }

        public async Task<VacancyDetailViewDto> Handle(GetAllVacancyDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var vacancies = await _vacancyDetailRepository.GetByIdAsync(request.Id);
            return _mapper.Map<VacancyDetailViewDto>(vacancies);
        }
    }
}
