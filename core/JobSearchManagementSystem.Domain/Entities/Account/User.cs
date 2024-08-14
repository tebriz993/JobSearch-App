using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Domain.Entities.Account
{
    public class User
    {

        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PassswordSalt { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

        public UserDetail UserDetail { get; set; }
    }
}
