using AutoMapper;
using FluentValidation;
using JobSearchManagementSystem.Application.Extensions;
using JobSearchManagementSystem.Application.Interfaces;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Command
{
    public class DeleteVacancyCommandHandler : IRequestHandler<DeleteVacancyCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<DeleteVacancyCommand> _validationRules;

        public DeleteVacancyCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<DeleteVacancyCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(DeleteVacancyCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var vacancyEntity = await _uow.VacanciesRepository.GetByIdAsync(request.Id);
            if (vacancyEntity == null)
            {
                throw new KeyNotFoundException("Vacancy detail not found");
            }
            await _uow.VacanciesRepository.Remove(vacancyEntity);
            await _uow.Commit();

        }
    }
}
