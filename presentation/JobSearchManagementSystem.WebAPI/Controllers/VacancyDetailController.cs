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
    [Authorize]
    public class VacancyDetailController : ApiControllerBase
    {
        public VacancyDetailController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [ActionName("vacancyDetails")]
        public async Task<ActionResult<ApiResponseModel<IEnumerable<VacancyDetailViewDto>>>> GetVacancyDetails()
        {
            var vacancyDetails = await _mediator.Send(new GetAllVacancyDetailQuery());
            return await SuccessResult("Vacancy details data is retrieved", vacancyDetails);
        }

        [HttpPost]
        [ActionName("vacancyDetails")]
        public async Task<ActionResult<ApiResponseModel<string>>> AddVacancyDetails(AddVacancyDetailCommand command)
        {
            await _mediator.Send(command);
            return await SuccessResult<string>("Vacancy detail added successfully");
        }

        [HttpPut]
        [ActionName("vacancyDetails")]
        
        public async Task<ActionResult<ApiResponseModel<string>>> UpdateVacancyDetails(UpdateVacancyDetailCommand command)
        {

            var user = User;
            await _mediator.Send(command);
            return await SuccessResult<string>("Vacancy detail updated successfully");
        }

        [HttpDelete("{id}")]
        [ActionName("vacancyDetails")]
        public async Task<ActionResult<ApiResponseModel<string>>> DeleteVacancyDetails(int id)
        {
            await _mediator.Send(new DeleteVacancyDetailCommand { Id = id });
            return await SuccessResult<string>("Vacancy detail deleted successfully");
        }
    }
}
