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
    public class CompanyController : ApiControllerBase
    {
        public CompanyController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [ActionName("companies")]
        public async Task<ActionResult<ApiResponseModel<IEnumerable<CompanyViewDto>>>> GetCompanies()
        {
            var companies = await _mediator.Send(new GetAllCompanyQuery());
            return await SuccessResult("Company datas is retrieved", companies);
        }

        [HttpPost]
        [ActionName("companies")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ApiResponseModel<string>>> AddCompanies([FromForm] AddCompanyCommand command)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validate the photo
            if (command.Photo == null)
            {
                ModelState.AddModelError("Photo", "Şəkil seçilməyib");
                return BadRequest(ModelState);
            }

            if (!command.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Tipi səhvdir");
                return BadRequest(ModelState);
            }

            if (command.Photo.Length / 1024 > 200)
            {
                ModelState.AddModelError("Photo", "Ölçü ödənmir");
                return BadRequest(ModelState);
            }

            // Generate a GUID for the image
            var filename = Guid.NewGuid().ToString() + Path.GetExtension(command.Photo.FileName);


            // Save the image to the server
            string path = Path.Combine(Directory.GetCurrentDirectory(), "assets", "img", filename);
            command.Image = path;
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await command.Photo.CopyToAsync(stream);
            }

            // Send the command to the mediator
            await _mediator.Send(command);

            return await SuccessResult<string>("Company added successfully");
        }


        [HttpDelete("{id}")]
        [ActionName("companies")]
        public async Task<ActionResult<ApiResponseModel<string>>> DeleteCompanies(int id)
        {
            await _mediator.Send(new DeleteCompanyCommand { Id = id });
            return await SuccessResult<string>("Company deleted successfully");
        }


    }
}
