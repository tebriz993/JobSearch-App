using System;

namespace JobSearchManagementSystem.Domain.Entities.Account
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; } // Added Address
        public string ProfilePicture { get; set; } // Added ProfilePicture
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
