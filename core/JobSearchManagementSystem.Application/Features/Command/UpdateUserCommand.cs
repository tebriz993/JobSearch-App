using Microsoft.AspNetCore.Http;
using MediatR;
using JobSearchManagementSystem.Application.Dtos;

namespace JobSearchManagementSystem.Application.Features.Command
{
    public class UpdateUserCommand : IRequest<AuthenticatedUserDto>
    {
        //public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public IFormFile ProfilePicture { get; set; } // Optional: to upload a profile picture
      
    }
}
