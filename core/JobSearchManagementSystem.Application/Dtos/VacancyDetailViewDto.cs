using JobSearchManagementSystem.Application.Mapper;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using System;

namespace JobSearchManagementSystem.Application.Dtos
{
    public class VacancyDetailViewDto: IMapTo<VacancyDetail>
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public byte[] ImageData { get; set; }
        
        public string VacancyName { get; set; }//
        public string CompanyName { get; set; }//

        public DateTime EndDate { get; set; }
        public int AnnouncementNumber { get; set; }

        public string JobInformations { get; set; }//
        public string AddressName { get; set; }//

        public byte MinExperience { get; set; }
        public byte MaxExperience { get; set; }

        public string CategoryName { get; set; }//
        public string JobTypesName { get; set; }//
        public string SpecialtyName{ get; set; }//
    }
}
