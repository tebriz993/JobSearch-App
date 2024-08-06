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
    public class UpdateVacancyCommandHandler: IRequestHandler<UpdateVacancyCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<UpdateVacancyCommand> _validationRules;

        public UpdateVacancyCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<UpdateVacancyCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(UpdateVacancyCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);

            var vacancyDetailEntity = _mapper.Map<Vacancy>(request);
            var editedVacancyDetail = await _uow.VacanciesRepository.GetByIdAsync(request.Id);

            editedVacancyDetail.Image = request.Image;
            editedVacancyDetail.Name = request.Name;
            editedVacancyDetail.CompanyId = request.CompanyId;
            await _uow.Commit();

        }
    }
}
