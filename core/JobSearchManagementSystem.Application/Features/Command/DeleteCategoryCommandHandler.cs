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
    public class DeleteCategoryCommandHandler: IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<DeleteCategoryCommand> _validationRules;

        public DeleteCategoryCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<DeleteCategoryCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var categoriesEntity = await _uow.CategoriesRepository.GetByIdAsync(request.Id);
            if (categoriesEntity is null)
            {
                throw new KeyNotFoundException("Category not found");
            }
            await _uow.CategoriesRepository.Remove(categoriesEntity);
            await _uow.Commit();

        }
    }
}
