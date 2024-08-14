using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Features.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using JobSearchManagementSystem.WebAPI;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using JobSearchManagementSystem.Application.Features.Queries;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using JobSearchManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace JobSearchManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateUserCommand> _createUserCommandValidator;
        private readonly IValidator<UpdateUserCommand> _updateUserCommandValidator;

        public AuthController(IMediator mediator, 
                               IValidator<CreateUserCommand> createUserCommandValidator,
                               IValidator<UpdateUserCommand> updateUserCommandValidator,
                               IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _createUserCommandValidator = createUserCommandValidator;
            _updateUserCommandValidator = updateUserCommandValidator;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [ActionName("SignUp")]
        public async Task<ActionResult<ApiResponseModel<AuthenticatedUserDto>>> Register(CreateUserCommand command)
        {
            var validationResult = await _createUserCommandValidator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ApiResponseModel<AuthenticatedUserDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Messages = validationResult.Errors.Select(e => e.ErrorMessage),
                    Result = null
                });
            }

            var result = await _mediator.Send(command);
            return Ok(new ApiResponseModel<AuthenticatedUserDto>
            {
                StatusCode = StatusCodes.Status200OK,
                Messages = new[] { "Token generated successfully" },
                Result = result
            });
        }

        [HttpPost]
        [ActionName("SignIn")]
        public async Task<ActionResult<ApiResponseModel<AuthenticatedUserDto>>> Login(GenerateTokenCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new ApiResponseModel<AuthenticatedUserDto>
            {
                StatusCode = StatusCodes.Status200OK,
                Messages = new[] { "Token generated successfully" },
                Result = result
            });
        }

        [HttpPut]
        [ActionName("Update")]
        public async Task<ActionResult<ApiResponseModel<AuthenticatedUserDto>>> Update([FromForm] UpdateUserCommand command)
        {
            // Retrieve UserId from the claims in the HttpContext
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null || !int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized(new ApiResponseModel<AuthenticatedUserDto>
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Messages = new[] { "User not authenticated" },
                    Result = null
                });
            }

            // Set the UserId in the command
            // The command itself will not have UserId, as it will be handled in the handler
            command.Email = command.Email; // Ensure other properties are set as needed

            var result = await _mediator.Send(command);

            return Ok(new ApiResponseModel<AuthenticatedUserDto>
            {
                StatusCode = StatusCodes.Status200OK,
                Messages = new[] { "User details updated successfully" },
                Result = result
            });
        }



        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ActionName("GetUsers")]
        public async Task<ActionResult<ApiResponseModel<IEnumerable<UserViewDto>>>> GetUsers()
        {
            // Check if the user is authenticated
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null || !int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized(new ApiResponseModel<IEnumerable<UserViewDto>>
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Messages = new[] { "User not authenticated" },
                    Result = null
                });
            }

            // Get the roles of the user
            var userRoles = await _unitOfWork.RoleRepository.GetUserRolesAsync(userId);

            // Check if the user has the required role (RoleId = 9)
            //var hasAdminRole = userRoles.Any(role => role.RoleId == 9);

            //if (!hasAdminRole)
            //{
            //    return StatusCode(StatusCodes.Status403Forbidden, new ApiResponseModel<IEnumerable<UserViewDto>>
            //    {
            //        StatusCode = StatusCodes.Status403Forbidden,
            //        Messages = new[] { "Only admins are allowed to access this resource" },
            //        Result = null
            //    });
            //}

            // If the user has the required role, retrieve the users data
            var users = await _mediator.Send(new GetUsersQuery());

            // Read profile pictures
            foreach (var user in users)
            {
                if (!string.IsNullOrEmpty(user.UserDetail.ProfilePicture))
                {
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), user.UserDetail.ProfilePicture);
                    if (System.IO.File.Exists(imagePath))
                    {
                        user.UserDetail.ImageData = await System.IO.File.ReadAllBytesAsync(imagePath);
                    }
                }
            }

            return Ok(new ApiResponseModel<IEnumerable<UserViewDto>>
            {
                StatusCode = StatusCodes.Status200OK,
                Messages = new[] { "Users data is retrieved" },
                Result = users
            });
        }





    }
}
