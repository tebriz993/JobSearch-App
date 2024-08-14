using AutoMapper;
using JobSearchManagementSystem.Application.Dtos;
using JobSearchManagementSystem.Application.Features.Command;
using JobSearchManagementSystem.Domain.Entities.Account;
using JobSearchManagementSystem.Domain.Entities.Jobs;

namespace JobSearchManagementSystem.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //For User
            CreateMap<CreateUserCommand, User>();
            CreateMap<CreateUserCommand, UserDetail>();
            CreateMap<User, UserViewDto>()
            .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role.RoleName)))
            .ForMember(dest => dest.UserDetail, opt => opt.MapFrom(src => src.UserDetail));

            CreateMap<UserDetail, UserDetailViewDto>();




            CreateMap<AddAddressCommand, Address>();


            //For Role
            CreateMap<Role, RoleViewDto>();
            CreateMap<AddRoleCommand, Role>();
            CreateMap<UpdateRoleCommand, Role>();
            CreateMap<DeleteRoleCommand, Role>();

            //For VacancyDetail
            CreateMap<VacancyDetailViewDto, VacancyDetail>();
            CreateMap<VacancyDetail, VacancyDetailViewDto>();
            CreateMap<AddVacancyDetailCommand, VacancyDetail>();
            CreateMap<UpdateVacancyDetailCommand, VacancyDetail>();
            CreateMap<DeleteVacancyDetailCommand, VacancyDetail>();

            //For Vacancy
            CreateMap<VacancyViewDto, Vacancy>();
            //CreateMap<Vacancy, VacancyViewDto>()
            // .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
            // .ReverseMap();
            CreateMap<AddVacancyCommand, Vacancy>();
            CreateMap<UpdateVacancyCommand, Vacancy>();
            CreateMap<DeleteVacancyCommand, Vacancy>();
            CreateMap<VacancyDetail, VacancyViewDto>();


            CreateMap<Companies, CompanyViewDto>();
            CreateMap<AddCompanyCommand, Companies>();
            CreateMap<Companies, CompanyViewDto>()
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.Image));

            CreateMap<Categories, CategoryViewDto>();
            CreateMap<AddCategoryCommand, Categories>();
            CreateMap<Categories, CategoryViewDto>()
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.Image));

            CreateMap<Vacancy, VacancyViewDto>();
            CreateMap<AddVacancyCommand, Vacancy>();
            CreateMap<Vacancy, VacancyViewDto>()
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.Image));

        }
    }
}
