using AutoMapper;
using JobSearchManagementSystem.Application.Features.Command;
using JobSearchManagementSystem.Application.Interfaces.Commons;
using MediatR;
using Microsoft.AspNetCore.Http;

public class UpdateVacancyCommandHandler : IRequestHandler<UpdateVacancyCommand, bool>
{
    private readonly IVacanciesRepository _vacanciesRepository;
    private readonly IMapper _mapper;

    public UpdateVacancyCommandHandler(IVacanciesRepository vacanciesRepository, IMapper mapper)
    {
        _vacanciesRepository = vacanciesRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateVacancyCommand request, CancellationToken cancellationToken)
    {
        var vacancy = await _vacanciesRepository.GetByIdAsync(request.Id);

        if (vacancy == null)
            return false;
            

        vacancy.Name = request.Name ?? vacancy.Name;

        // Handle file upload if Photo is provided
        if (request.Photo != null)
        {
            // Save the file and get the file path
            var filePath = await SaveFileAsync(request.Photo);
            vacancy.Image = filePath;
        }
        else
        {
            // Keep the existing image path if no new photo is provided
            vacancy.Image = request.Image ?? vacancy.Image;
        }

        await _vacanciesRepository.Update(vacancy);
        await _vacanciesRepository.SaveChanges();
        return true;
       
    }

    private async Task<string> SaveFileAsync(IFormFile file)
    {
        // Generate a GUID for the image file name
        var filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

        // Define the relative path where the file will be saved
        var relativePath = Path.Combine("assets", "img", filename);
        var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);

        // Ensure the directory exists
        var uploadsFolder = Path.GetDirectoryName(absolutePath);
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        // Save the file to the server
        using (var stream = new FileStream(absolutePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // Return the relative path of the saved file
        return absolutePath;
    }
}
