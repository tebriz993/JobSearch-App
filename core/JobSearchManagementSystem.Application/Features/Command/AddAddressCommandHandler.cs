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
    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<AddAddressCommand> _validationRules;

        public AddAddressCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<AddAddressCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var addressEntity = _mapper.Map<Address>(request);
            await _uow.AddressRepository.AddAsync(addressEntity);
            await _uow.Commit();
        }
    }
}
