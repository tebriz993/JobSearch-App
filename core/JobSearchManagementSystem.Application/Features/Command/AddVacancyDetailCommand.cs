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
    public class AddVacancyDetailCommand: IMapTo<VacancyDetail>, IRequest
    {
        public string Image { get; set; }
        public int VacancyId { get; set; }

        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }

        public DateTime EndDate { get; set; }
        public int AnnouncementNumber { get; set; }

        public int JobInformationId { get; set; }

        public int AddressId { get; set; }

        public byte MinExperience { get; set; }
        public byte MaxExperience { get; set; }

        public int CategoryId { get; set; }

        public int JobTypesId { get; set; }  //Full time, part-time ves.
        public int SpecialtiesId { get; set; }
    }
}
