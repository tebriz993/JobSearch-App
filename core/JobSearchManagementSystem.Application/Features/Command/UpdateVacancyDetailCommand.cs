using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Command
{
    public class UpdateVacancyDetailCommand:IRequest
    {
        public int Id { get; set; }

        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }


        public int VacancyId { get; set; }
        public int CompanyId { get; set; }


        public DateTime EndDate { get; set; }
        public int AnnouncementNumber { get; set; }


        public int JobInformationId { get; set; }
        public int AddressId { get; set; }


        public byte MinExperience { get; set; }

        public byte MaxExperience { get; set; }


        public int CategoriesId { get; set; }
        public int JobTypeId { get; set; }
        public int SpecialtiesId { get; set; }
    }
}
