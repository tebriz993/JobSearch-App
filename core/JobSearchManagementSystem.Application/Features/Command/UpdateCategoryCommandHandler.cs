using AutoMapper;
using JobSearchManagementSystem.Application.Features.Command;
using JobSearchManagementSystem.Application.Interfaces.Commons;
using MediatR;
using Microsoft.AspNetCore.Http;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(ICategoriesRepository categoriesRepository, IMapper mapper)
    {
        _categoriesRepository = categoriesRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var company = await _categoriesRepository.GetByIdAsync(request.Id);

        if (company is null)
            return false;

        company.Name = request.Name ?? company.Name;

        // Handle file upload if Photo is provided
        if (request.Photo is not null)
        {
            // Save the file and get the file path
            var filePath = await SaveFileAsync(request.Photo);
            company.Image = filePath;
        }
        else
        {
            // Keep the existing image path if no new photo is provided
            company.Image = request.Image ?? company.Image;
        }

        await _categoriesRepository.Update(company);
        await _categoriesRepository.SaveChanges();

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
