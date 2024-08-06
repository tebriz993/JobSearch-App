using JobSearchManagementSystem.Application.Mapper;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Dtos
{
    public class AddressViewDto:IMapTo<Address>
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AddressName { get; set; }
    }
}
