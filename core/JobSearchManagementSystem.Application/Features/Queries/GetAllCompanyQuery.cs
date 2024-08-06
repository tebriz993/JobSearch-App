using JobSearchManagementSystem.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Features.Queries
{
    public class GetAllCompanyQuery:IRequest<IEnumerable<CompanyViewDto>>
    {

    }
}
