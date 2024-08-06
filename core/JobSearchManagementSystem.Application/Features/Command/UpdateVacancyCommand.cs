using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Command
{
    public class UpdateVacancyCommand:IRequest
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
    }
}
