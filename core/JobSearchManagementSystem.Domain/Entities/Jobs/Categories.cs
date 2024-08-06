using JobSearchManagementSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Domain.Entities.Jobs
{
    public class Categories:BaseEntity
    {
        public Categories()
        {
            VacancyDetails=new HashSet<VacancyDetail>();
        }
        public string Image { get; set; }
        public string Name { get; set; }
        public ICollection<VacancyDetail> VacancyDetails { get; set; }
    }
}
