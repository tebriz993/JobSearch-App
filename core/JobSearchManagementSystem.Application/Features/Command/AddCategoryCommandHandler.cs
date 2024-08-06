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
    public class AddCategoryCommandHandler:IRequestHandler<AddCategoryCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<AddCategoryCommand> _validationRules;

        public AddCategoryCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<AddCategoryCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var addressEntity = _mapper.Map<Categories>(request);
            await _uow.CategoriesRepository.AddAsync(addressEntity);
            await _uow.Commit();
        }
    }
}
