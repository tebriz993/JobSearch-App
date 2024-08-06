using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Command
{
    public class DeleteVacancyCommand:IRequest
    {
        public int Id { get; set; }
    }
}
