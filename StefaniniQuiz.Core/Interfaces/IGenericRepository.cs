using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> AddAsync(T entity);
        Task<bool> EditAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteAsync(T entity);

        



    }
}
