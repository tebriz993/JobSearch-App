using JobSearchManagementSystem.Application.Mapper;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Dtos
{
    public class VacancyViewDto:IMapTo<Vacancy>
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
    }
}
