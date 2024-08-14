using AutoMapper;
using JobSearchManagementSystem.Application.Features.Command;
using JobSearchManagementSystem.Application.Interfaces.Commons;
using MediatR;
using Microsoft.AspNetCore.Http;

public class UpdateVacancyDetailCommandHandler : IRequestHandler<UpdateVacancyCommand, bool>
{
    private readonly IVacancyDetailRepository _vacancyDetailRepository;
    private readonly IMapper _mapper;

    public UpdateVacancyDetailCommandHandler(IVacancyDetailRepository vacancyDetailRepository, IMapper mapper)
    {
        _vacancyDetailRepository = vacancyDetailRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateVacancyCommand request, CancellationToken cancellationToken)
    {
        var vacancyDetail = await _vacancyDetailRepository.GetByIdAsync(request.Id);

        if (vacancyDetail == null)
        {
            throw new ArgumentException("Vacancy detail is null");
        }
            

        // Handle file upload if Photo is provided
        if (request.Photo != null)
        {
            // Save the file and get the file path
            var filePath = await SaveFileAsync(request.Photo);
            vacancyDetail.Image = filePath;
        }
        else
        {
            // Keep the existing image path if no new photo is provided
            vacancyDetail.Image = request.Image ?? vacancyDetail.Image;
        }

        await _vacancyDetailRepository.Update(vacancyDetail);
        await _vacancyDetailRepository.SaveChanges();
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
