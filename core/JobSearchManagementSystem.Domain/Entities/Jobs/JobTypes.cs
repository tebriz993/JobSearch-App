using JobSearchManagementSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Domain.Entities.Jobs
{
    public class JobTypes:BaseEntity
    {
        public JobTypes()
        {
            VacancyDetails=new HashSet<VacancyDetail>();
        }
        public string Name { get; set; }
        public ICollection<VacancyDetail> VacancyDetails { get; set; }
    }
}
