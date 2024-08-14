using JobSearchManagementSystem.Application.Interfaces;
using JobSearchManagementSystem.Application.Interfaces.Account;
using JobSearchManagementSystem.Application.Interfaces.Commons;
using JobSearchManagementSystem.Domain.Entities.Common;
using JobSearchManagementSystem.Persistance.EntityFrameworks.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Persistance.EntityFrameworks.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JobSearchDbContext _dbcontext;
        private readonly Dictionary<Type, object> _repositories;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UnitOfWork(JobSearchDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _repositories = new Dictionary<Type, object>();
            _dbcontext = context;
            _dbcontext.Database.BeginTransactionAsync();
            _httpContextAccessor = httpContextAccessor;
        }

        public IAddressRepository AddressRepository => SetRepository<IAddressRepository>();

        public ICategoriesRepository CategoriesRepository => SetRepository<ICategoriesRepository>();

        public ICompaniesRepository CompaniesRepository => SetRepository<ICompaniesRepository>();

        public IJobDetailInformationRepository JobDetailInformationRepository => SetRepository<IJobDetailInformationRepository>();

        public IJobInformationRepository JobInformationRepository => SetRepository<IJobInformationRepository>();

        public IJobTypesRepository JobTypesRepository => SetRepository<IJobTypesRepository>();

        public IVacancyDetailRepository VacancyDetailRepository => SetRepository<IVacancyDetailRepository>();

        public IUserRepository UserRepository => SetRepository<IUserRepository>();

        public IVacanciesRepository VacanciesRepository => SetRepository<IVacanciesRepository>();

        public ISpecialtiesRepository SpecialtiesRepository => SetRepository<ISpecialtiesRepository>();

        public IRoleRepository RoleRepository => SetRepository<IRoleRepository>();


        public async Task CommitTransaction()
        {
            await _dbcontext.Database.CommitTransactionAsync();
        }

        public async Task Commit(CancellationToken cancellationToken = default)
        {

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            IEnumerable<EntityEntry<BaseEntity>> entities = _dbcontext
              .ChangeTracker
              .Entries<BaseEntity>()
              .ToList();

            foreach (var entry in entities)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedId = Convert.ToInt32(userId);

                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedId = Convert.ToInt32(userId);
                }
            }

            await _dbcontext.SaveChangesAsync(cancellationToken);
            await CommitTransaction();

        }

        public TRepository GetReposiroty<TRepository>() where TRepository : class
        {
            throw new NotImplementedException();
        }

        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {

            foreach (var entry in _dbcontext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }


        public TRepository SetRepository<TRepository>()
        {
            if (_repositories.ContainsKey(typeof(TRepository)))
            {
                return (TRepository)_repositories[typeof(TRepository)];
            }

            var repositoryType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => !x.IsInterface && x.IsClass && x.IsAssignableTo(typeof(TRepository)));

            var repositoryInstance = (TRepository)Activator.CreateInstance(repositoryType, _dbcontext);
            _repositories.Add(typeof(TRepository), repositoryInstance);
            return repositoryInstance;
        }
    }
}
