using JobSearchManagementSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Domain.Entities.Jobs
{
    public class VacancyDetail:BaseEntity
    {
        public string Image { get; set; }

        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }

        public int CompanyId { get; set; }
        public Companies Company { get; set; }


        public DateTime EndDate { get; set; }
        public int AnnouncementNumber { get; set; }


        public int JobInformationId { get; set; }
        public JobInformation JobInformation { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public byte MinExperience { get; set; }
        public byte MaxExperience { get; set; }

        public int SpecialtiesId { get; set; }
        public Specialties Specialties { get; set; }

        public int JobTypesId { get; set; }  //Full time, part-time ves.
        public JobTypes JobTypes { get; set; }

        public int CategoryId { get; set; }
        public Categories Categories { get; set; }
    }
}
