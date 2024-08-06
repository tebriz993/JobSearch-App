using JobSearchManagementSystem.Application.Mapper;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using System;

namespace JobSearchManagementSystem.Application.Dtos
{
    public class VacancyDetailViewDto: IMapTo<VacancyDetail>
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int VacancyId { get; set; }
        public int CompanyId { get; set; }
        public DateTime EndDate { get; set; }
        public int AnnouncementNumber { get; set; }
        public int JobInformationId { get; set; }
        public int AddressId { get; set; }

        public byte MinExperience { get; set; }
        public byte MaxExperience { get; set; }

        public int CategoryId { get; set; }
        public int JobTypesId { get; set; }
        public int SpecialtiesId { get; set; }
    }
}
