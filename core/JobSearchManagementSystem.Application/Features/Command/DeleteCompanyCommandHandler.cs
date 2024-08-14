using AutoMapper;
using FluentValidation;
using JobSearchManagementSystem.Application.Extensions;
using JobSearchManagementSystem.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Command
{
    public class DeleteCompanyCommandHandler:IRequestHandler<DeleteCompanyCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<DeleteCompanyCommand> _validationRules;

        public DeleteCompanyCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<DeleteCompanyCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var companiesEntity = await _uow.CompaniesRepository.GetByIdAsync(request.Id);
            if (companiesEntity is null)
            {
                throw new KeyNotFoundException("Company not found");
            }
            await _uow.CompaniesRepository.Remove(companiesEntity);
            await _uow.Commit();

        }
    }
}
