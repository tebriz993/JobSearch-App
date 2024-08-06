using AutoMapper;
using FluentValidation;
using JobSearchManagementSystem.Application.Extensions;
using JobSearchManagementSystem.Application.Interfaces;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using MediatR;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Command
{
    public class AddVacancyDetailCommandHandler: IRequestHandler<AddVacancyDetailCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<AddVacancyDetailCommand> _validationRules;

        public AddVacancyDetailCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<AddVacancyDetailCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(AddVacancyDetailCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);

            var vacancyDetailEntity = _mapper.Map<VacancyDetail>(request);
            if (request.CompanyId is null)
            {
                vacancyDetailEntity.Company = new Companies
                {
                    Name = request.CompanyName
                };
            }
          
            await _uow.VacancyDetailRepository.AddAsync(vacancyDetailEntity);
            await _uow.Commit();
             
        }
    }
}
