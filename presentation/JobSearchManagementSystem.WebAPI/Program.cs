using JobSearchManagementSystem.Persistance;
using JobSearchManagementSystem.Application;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.OpenApi.Models;
using JobSearchManagementSystem.Application.Validators.FluentValidators;
using JobSearchManagementSystem.Application.Interfaces.Commons;
using JobSearchManagementSystem.Persistance.EntityFrameworks.Repositories;
using JobSearchManagementSystem.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Persistans v? Application xidm?tl?rini ?lav? etm?k.
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddApplicationServices();

//sonradan elave etdim
builder.Services.AddScoped<ICompaniesRepository, EFCompaniesRepository>();
builder.Services.AddScoped<ICategoriesRepository, EFCategoriesRepository>();
builder.Services.AddScoped<IVacanciesRepository, EFVacanciesRepository>();
builder.Services.AddScoped<IVacancyDetailRepository, EFVacancyDetailRepository>();

    

// FluentValidation-u ?lav? etm?k.
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>())
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.IgnoreNullValues = true; // Optional
    });

// Swagger konfiqurasiyas?.
builder.Services.AddSwaggerGen(options =>
{
    var basicSecurityScheme = new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    options.AddSecurityDefinition(basicSecurityScheme.Reference.Id, basicSecurityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { basicSecurityScheme, Array.Empty<string>() }
    });
});

// JWT do?rulama konfiqurasiyas?.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c")),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });

// API Explorer v? Swagger/OpenAPI konfiqurasiyas?.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseAuthentication(); // JWT do?rulama üçün authentication-i istifad? etm?k.
app.UseAuthorization();

app.MapControllers();

app.Run();
