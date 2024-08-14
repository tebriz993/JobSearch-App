using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Features.Command;
using JobSearchManagementSystem.Application.Features.Queries;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using JobSearchManagementSystem.Persistance.EntityFrameworks.Repositories;
using JobSearchManagementSystem.WebAPI;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
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
        [ActionName("vacancies")]
        public async Task<ActionResult<ApiResponseModel<IEnumerable<VacancyViewDto>>>> GetVacancies()
        {
            var vacancies = await _mediator.Send(new GetAllVacancyQuery());

            foreach (var vacancy in vacancies)
            {
                if (!string.IsNullOrEmpty(vacancy.ImagePath))
                {
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), vacancy.ImagePath);
                    if (System.IO.File.Exists(imagePath))
                    {
                        vacancy.ImageData = await System.IO.File.ReadAllBytesAsync(imagePath);
                    }

                }
            }

            return await SuccessResult("Vacancy data is retrieved", vacancies);
        }


        [HttpPost]
        [ActionName("vacancies")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ApiResponseModel<string>>> AddVacancies([FromForm] AddVacancyCommand command)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validate the photo
            if (command.Photo is null)
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
            string relativePath = Path.Combine("assets", "img", filename);
            string absolutePath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);

            using (var stream = new FileStream(absolutePath, FileMode.Create))
            {
                await command.Photo.CopyToAsync(stream);
            }

            // Set the image path internally in the command
            command.Image = absolutePath;

            // Send the command to the mediator
            await _mediator.Send(command);

            // Return the full path in the response
            return await SuccessResult<string>($"Vacancy added successfully. Image path: {absolutePath}");
        }


        [HttpPut]
        [ActionName("vacancies")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ApiResponseModel<string>>> UpdateVacancies([FromForm] UpdateVacancyCommand command)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Retrieve the existing company directly from the repository
            var company = await _mediator.Send(new GetAllVacancyByIdQuery { Id = command.Id });

            if (company == null)
            {
                return NotFound();
            }

            // Validate the photo if provided
            if (command.Photo != null)
            {
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
                var relativePath = Path.Combine("assets", "img", filename);
                var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);

                // Ensure the directory exists
                var uploadsFolder = Path.GetDirectoryName(absolutePath);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                using (var stream = new FileStream(absolutePath, FileMode.Create))
                {
                    await command.Photo.CopyToAsync(stream);
                }

                // Set the image path internally in the command
                command.Image = relativePath;
            }
            else
            {
                // Keep the existing image path if no new photo is provided
                command.Image = company.ImagePath;
            }


            // Send the update command to the mediator
            await _mediator.Send(command);

            // Return the full path in the response
            var resultMessage = command.Photo != null
                ? $"Vacancy updated successfully. New image path: {Path.Combine(Directory.GetCurrentDirectory(), command.Image)}"
                : "Vacancy updated successfully. No new image uploaded.";

            return await SuccessResult<string>(resultMessage);
        }


        [HttpDelete("{id}")]
        [ActionName("vacancies")]
        public async Task<ActionResult<ApiResponseModel<string>>> DeleteVacancies(int id)
        {
            await _mediator.Send(new DeleteVacancyCommand { Id = id });
            return await SuccessResult<string>("Vacancy deleted successfully");
        }
    }
}
