using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace JobSearchManagementSystem.Application.Features.Command
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
