using AutoMapper;
using FluentValidation;
using JobSearchManagementSystem.Application.Features.Command;
using JobSearchManagementSystem.Application.Interfaces.Commons;
using JobSearchManagementSystem.Application.Validators.FluentValidators;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JobSearchManagementSystem.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {


            services.AddScoped(typeof(AbstractValidator<AddAddressCommand>), typeof(AddAddressCommandValidator));

            //For User
            services.AddScoped(typeof(AbstractValidator<CreateUserCommand>), typeof(CreateUserCommandValidator));
            services.AddScoped(typeof(AbstractValidator<UpdateUserCommand>), typeof(UpdateUserCommandValidator));


            //For Role
            services.AddScoped(typeof(AbstractValidator<AddRoleCommand>), typeof(AddRoleCommandValidator));
            services.AddScoped(typeof(AbstractValidator<UpdateRoleCommand>), typeof(UpdateRoleCommandValidator));
            services.AddScoped(typeof(AbstractValidator<DeleteRoleCommand>), typeof(DeleteRoleCommandValidator));

            //For VacancyDetail
            services.AddScoped(typeof(AbstractValidator<AddVacancyDetailCommand>), typeof(AddVacancyDetailCommandValidator));
            services.AddScoped(typeof(AbstractValidator<UpdateVacancyDetailCommand>), typeof(UpdateVacancyDetailCommandValidator));
            services.AddScoped(typeof(AbstractValidator<DeleteVacancyDetailCommand>), typeof(DeleteVacancyDetailCommandValidator));

            //For Vacancy
            services.AddScoped(typeof(AbstractValidator<AddVacancyCommand>), typeof(AddVacancyCommandValidator));
            services.AddScoped(typeof(AbstractValidator<UpdateVacancyCommand>), typeof(UpdateVacancyCommandValidator));
            services.AddScoped(typeof(AbstractValidator<DeleteVacancyCommand>), typeof(DeleteVacancyCommandValidator));

            //For Category
            services.AddScoped(typeof(AbstractValidator<AddCategoryCommand>), typeof(AddCategoriesCommandValidator));
            services.AddScoped(typeof(AbstractValidator<UpdateCategoryCommand>), typeof(UpdateCategoryCommandValidator));
            services.AddScoped(typeof(AbstractValidator<DeleteCategoryCommand>), typeof(DeleteCategoryCommandValidator));

            //For Company
            services.AddScoped(typeof(AbstractValidator<AddCompanyCommand>), typeof(AddCompanyCommandValidator));
            services.AddScoped(typeof(AbstractValidator<UpdateCompanyCommand>), typeof(UpdateCompanyCommandValidator));
            services.AddScoped(typeof(AbstractValidator<DeleteCompanyCommand>), typeof(DeleteCompanyCommandValidator));


            services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
