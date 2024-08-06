using JobSearchManagementSystem.Application.Mapper;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Command
{
    public class AddAddressCommand:IMapTo<Address>, IRequest
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string AddressName { get; set; }
    }
}
