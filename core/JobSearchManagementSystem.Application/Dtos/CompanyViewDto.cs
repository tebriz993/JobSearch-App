using JobSearchManagementSystem.Application.Mapper;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchManagementSystem.Application.Dtos
{
    public class CompanyViewDto : IMapTo<Companies>
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public byte[] ImageData { get; set; }
        //[NotMapped]
        //public IFormFile Photo { get; set; }
        public string Name { get; set; }
    }
}