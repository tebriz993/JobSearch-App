using AutoMapper;
using FluentValidation;
using JobSearchManagementSystem.Application.Extensions;
using JobSearchManagementSystem.Application.Interfaces;
using JobSearchManagementSystem.Application.Interfaces.Commons;
using JobSearchManagementSystem.Domain.Entities.Account;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Command
{
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand>
    {
      
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AbstractValidator<AddRoleCommand> _validator;

        public AddRoleCommandHandler(IMapper mapper, AbstractValidator<AddRoleCommand> validator, IUnitOfWork unitOfWork)
        {
        
            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            await _validator.ThrowIfValidationFailAsync(request);

            var roleEntity = _mapper.Map<Role>(request);
            await _unitOfWork.RoleRepository.AddAsync(roleEntity);
            await _unitOfWork.Commit();

        }

        
    }
}
