using AutoMapper;
using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Queries
{
    public class GetAllAddressQueryHandler : IRequestHandler<GetAllAddressQuery,IEnumerable<AddressViewDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllAddressQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AddressViewDto>> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
        {
            var adresses = await _uow.AddressRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AddressViewDto>>(adresses);
        }
    }
}
