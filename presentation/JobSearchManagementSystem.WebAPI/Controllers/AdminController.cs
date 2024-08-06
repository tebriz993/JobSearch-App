using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Features.Command;
using JobSearchManagementSystem.Application.Features.Queries;
using JobSearchManagementSystem.WebAPI;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ApiControllerBase
    {
        public AdminController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [ActionName("roles")]
        public async Task<ActionResult<ApiResponseModel<IEnumerable<RoleViewDto>>>> GetAllRolesAsync()
        {
            var roles = await _mediator.Send(new GetAllRolesQuery());
            return await SuccessResult("Roles data is retrieved", roles);
        }

        [HttpPost]
        [ActionName("roles")]
        public async Task<ActionResult<ApiResponseModel<string>>> AddRole(AddRoleCommand command)
        {
            await _mediator.Send(command);
            return await SuccessResult<string>("Role added successfully");
        }

        [HttpPut]
        [ActionName("roles")]
        public async Task<ActionResult<ApiResponseModel<string>>> UpdateRole(UpdateRoleCommand command)
        {
            await _mediator.Send(command);
            return await SuccessResult<string>("Role updated successfully");
        }

        [HttpDelete]
        [ActionName("roles")]
        public async Task<ActionResult<ApiResponseModel<string>>> DeleteRole(DeleteRoleCommand command)
        {
            await _mediator.Send(command);
            return await SuccessResult<string>("Role deleted successfully");
        }
    }
}
