using AutoMapper;
using FluentValidation;
using JobSearchManagementSystem.Application.Extensions;
using JobSearchManagementSystem.Application.Interfaces;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Command
{
    public class AddVacancyCommandHandler:IRequestHandler<AddVacancyCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<AddVacancyCommand> _validationRules;

        public AddVacancyCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<AddVacancyCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(AddVacancyCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);

            var vacancyEntity = _mapper.Map<Vacancy>(request);
            if (request.CompanyId is null)
            {
                vacancyEntity.Company = new Companies
                {
                    Name = request.CompanyName
                };
            }

            await _uow.VacanciesRepository.AddAsync(vacancyEntity);
            await _uow.Commit();
        }
    }
}
