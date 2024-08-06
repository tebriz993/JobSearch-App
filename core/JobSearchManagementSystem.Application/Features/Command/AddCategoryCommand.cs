using JobSearchManagementSystem.Application.Mapper;
using JobSearchManagementSystem.Domain.Entities.Jobs;
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
    public class AddCategoryCommand:IMapTo<Categories>, IRequest
    {
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string Name { get; set; }
    }
}
