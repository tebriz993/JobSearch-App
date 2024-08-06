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
    public class UpdateVacancyDetailCommandHandler : IRequestHandler<UpdateVacancyDetailCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<UpdateVacancyDetailCommand> _validationRules;

        public UpdateVacancyDetailCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<UpdateVacancyDetailCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(UpdateVacancyDetailCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);

            var vacancyDetailEntity = _mapper.Map<VacancyDetail>(request);
            var editedVacancyDetail = await _uow.VacancyDetailRepository.GetByIdAsync(request.Id);

            editedVacancyDetail.Image = request.Image;
            editedVacancyDetail.AnnouncementNumber = request.AnnouncementNumber;
            editedVacancyDetail.VacancyId = request.VacancyId;
            editedVacancyDetail.SpecialtiesId = request.SpecialtiesId;
            editedVacancyDetail.MinExperience = request.MinExperience;
            editedVacancyDetail.MaxExperience = request.MaxExperience;
            editedVacancyDetail.CategoryId = request.CategoryId;
            editedVacancyDetail.JobInformationId = request.JobInformationId;
            editedVacancyDetail.CompanyId = request.CompanyId;
            await _uow.Commit();

        }
    }
}
