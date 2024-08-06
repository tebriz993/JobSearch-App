using FluentValidation;
using JobSearchManagementSystem.Application.Interfaces;
using JobSearchManagementSystem.Application.Interfaces.Commons;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Command
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
    {
        
        private readonly AbstractValidator<DeleteRoleCommand> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoleCommandHandler(AbstractValidator<DeleteRoleCommand> validator, IUnitOfWork unitOfWork)
        {
            
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var roleEntity = await _unitOfWork.RoleRepository.GetByIdAsync(request.Id);
            if (roleEntity != null)
            {
                await _unitOfWork.RoleRepository.DeleteAsync(roleEntity);
                await _unitOfWork.Commit();
            }

            
        }
    }
}
