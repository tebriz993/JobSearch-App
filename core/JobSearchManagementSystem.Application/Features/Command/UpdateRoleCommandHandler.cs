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
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
    {
        
        private readonly IMapper _mapper;
        private readonly AbstractValidator<UpdateRoleCommand> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRoleCommandHandler(IMapper mapper, AbstractValidator<UpdateRoleCommand> validator, IUnitOfWork unitOfWork)
        {
            
            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            await _validator.ThrowIfValidationFailAsync(request);

            var roleEntity = _mapper.Map<Role>(request);
            await _unitOfWork.RoleRepository.UpdateAsync(roleEntity);
            await _unitOfWork.Commit();

           
        }

       
    }
}
