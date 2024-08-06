using JobSearchManagementSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Domain.Entities.Jobs
{
    public class JobInformation:BaseEntity
    {
        public JobInformation()
        {
            VacancyDetails=new HashSet<VacancyDetail>();
        }
        public string Title { get; set; }
        public ICollection<VacancyDetail> VacancyDetails { get; set; }

        public int JobDetailInformationId { get; set; }
        public JobDetailnformation JobDetailInformations { get; set; }
    }
}
