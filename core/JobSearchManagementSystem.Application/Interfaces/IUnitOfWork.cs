using JobSearchManagementSystem.Application.Interfaces.Account;
using JobSearchManagementSystem.Application.Interfaces.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
        void Rollback();
        TRepository SetRepository<TRepository>();
        TRepository GetReposiroty<TRepository>() where TRepository : class;

        IAddressRepository AddressRepository { get; }
        ICategoriesRepository CategoriesRepository { get; }
        ICompaniesRepository CompaniesRepository { get; }
        IJobDetailInformationRepository JobDetailInformationRepository { get; }
        IJobInformationRepository JobInformationRepository { get; }
        IJobTypesRepository JobTypesRepository { get; }
        IVacancyDetailRepository VacancyDetailRepository { get; }
        IUserRepository UserRepository { get; }
        IVacanciesRepository VacanciesRepository { get; }
        ISpecialtiesRepository SpecialtiesRepository { get; }
        IRoleRepository RoleRepository { get; }
    }
}
