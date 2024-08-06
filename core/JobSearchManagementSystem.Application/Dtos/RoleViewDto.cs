using JobSearchManagementSystem.Application.Mapper;
using JobSearchManagementSystem.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Dtos
{
    public class RoleViewDto:IMapTo<Role>
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
