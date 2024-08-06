using JobSearchManagementSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Domain.Entities.Jobs
{
    public class Address:BaseEntity
    {
        public Address()
        {
            VacancyDetails = new HashSet<VacancyDetail>();
        }

        public string Country { get; set; }
        public string City { get; set; }
        public string AddressName { get; set; }
        public ICollection<VacancyDetail> VacancyDetails { get; set; }
    }
}
