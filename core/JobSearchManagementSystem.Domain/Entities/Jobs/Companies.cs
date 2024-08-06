using JobSearchManagementSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Domain.Entities.Jobs
{
    public class Companies:BaseEntity
    {
        public Companies()
        {
            VacancyDetails=new HashSet<VacancyDetail>();
            Vacancies = new HashSet<Vacancy>();
        }

        public string Image { get; set; }
        public string Name { get; set; }
        public ICollection<VacancyDetail> VacancyDetails { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
