using AutoMapper;
using JobSearchManagementSystem.Application.Features.Command;
using JobSearchManagementSystem.Application.Interfaces.Commons;
using MediatR;
using Microsoft.AspNetCore.Http;

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, bool>
{
    private readonly ICompaniesRepository _companiesRepository;
    private readonly IMapper _mapper;

    public UpdateCompanyCommandHandler(ICompaniesRepository companiesRepository, IMapper mapper)
    {
        _companiesRepository = companiesRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _companiesRepository.GetByIdAsync(request.Id);

        if (company == null)
            return false;

        company.Name = request.Name ?? company.Name;

        // Handle file upload if Photo is provided
        if (request.Photo != null)
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

        await _companiesRepository.Update(company);
        await _companiesRepository.SaveChanges();

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
