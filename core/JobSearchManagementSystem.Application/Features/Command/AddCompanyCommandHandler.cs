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
    public class AddCompanyCommandHandler:IRequestHandler<AddCompanyCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<AddCompanyCommand> _validationRules;

        public AddCompanyCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<AddCompanyCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var companyEntity = _mapper.Map<Companies>(request);
            await _uow.CompaniesRepository.AddAsync(companyEntity);
            await _uow.Commit();
        }
    }
}
