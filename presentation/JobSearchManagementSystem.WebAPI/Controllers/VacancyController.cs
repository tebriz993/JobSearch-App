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
    public class VacancyController : ApiControllerBase
    {
        public VacancyController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [ActionName("vacancyDetails")]
        public async Task<ActionResult<ApiResponseModel<IEnumerable<VacancyViewDto>>>> GetVacancies()
        {
            var vacancyDetails = await _mediator.Send(new GetAllVacancyQuery());
            return await SuccessResult("Vacancy details data is retrieved", vacancyDetails);
        }

        [HttpPost]
        [ActionName("vacancyDetails")]
        public async Task<ActionResult<ApiResponseModel<string>>> AddVacancies(AddVacancyCommand command)
        {
            await _mediator.Send(command);
            return await SuccessResult<string>("Vacancy added successfully");
        }

        [HttpPut]
        [ActionName("vacancyDetails")]

        public async Task<ActionResult<ApiResponseModel<string>>> UpdateVacancies(UpdateVacancyCommand command)
        {

            var user = User;
            await _mediator.Send(command);
            return await SuccessResult<string>("Vacancy updated successfully");
        }

        [HttpDelete("{id}")]
        [ActionName("vacancyDetails")]
        public async Task<ActionResult<ApiResponseModel<string>>> DeleteVacancies(int id)
        {
            await _mediator.Send(new DeleteVacancyCommand { Id = id });
            return await SuccessResult<string>("Vacancy deleted successfully");
        }
    }
}
