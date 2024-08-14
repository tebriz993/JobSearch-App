using JobSearchManagementSystem.Application.Mapper;
using JobSearchManagementSystem.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Dtos
{
    public class UserDetailViewDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ProfilePicture { get; set; }
        public byte[] ImageData { get; set; }
    }
}
