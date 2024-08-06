using JobSearchManagementSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Domain.Entities.Jobs
{
    public class Vacancy:BaseEntity
    {
        public Vacancy()
        {
            VacancyDetails = new HashSet<VacancyDetail>();
        }

        public string Image { get; set; }
        public string Name { get; set; }
       
        public int CompanyId { get; set; }
        public Companies Company { get; set; }
        public ICollection<VacancyDetail> VacancyDetails { get; set; }
    }
}
