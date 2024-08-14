using JobSearchManagementSystem.Application.Mapper;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobSearchManagementSystem.Application.Features.Command
{
    public class AddCompanyCommand : IMapTo<Companies>, IRequest
    {
        [JsonIgnore]
        public string Image { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

        public string Name { get; set; }
    }
}