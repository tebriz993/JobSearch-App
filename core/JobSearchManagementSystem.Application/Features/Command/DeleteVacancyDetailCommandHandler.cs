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
    public class DeleteVacancyDetailCommandHandler : IRequestHandler<DeleteVacancyDetailCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<DeleteVacancyDetailCommand> _validationRules;

        public DeleteVacancyDetailCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<DeleteVacancyDetailCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(DeleteVacancyDetailCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var vacancyDetailEntity = await _uow.VacancyDetailRepository.GetByIdAsync(request.Id);
            if (vacancyDetailEntity == null)
            {
                throw new KeyNotFoundException("Vacancy detail not found");
            }
            await _uow.VacancyDetailRepository.Remove(vacancyDetailEntity);
            await _uow.Commit();
            
        }
    }
}
