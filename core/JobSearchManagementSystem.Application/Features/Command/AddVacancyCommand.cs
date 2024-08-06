using AutoMapper;
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
    public class AddVacancyCommand:IMapTo<Vacancy>, IRequest
    {
        public string Image { get; set; }
        public string Name { get; set; }

        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
