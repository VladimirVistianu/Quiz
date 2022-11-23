using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task<ICollection<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<bool> AddAsync(T entity);
        Task<bool> EditAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteAsync(T entity);

        Task<T> GetByIdAsync(Guid id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);






    }
}
