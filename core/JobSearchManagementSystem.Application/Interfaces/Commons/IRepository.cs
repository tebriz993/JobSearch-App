using JobSearchManagementSystem.Domain.Entities.Common;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Interfaces.Commons
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(bool trackimg = true);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> expression);
        Task<bool> AddAsync(T entity);
        Task SaveChanges();
        Task<bool> Update(T entity);
        Task<bool> Remove(T entity);
    }
}
