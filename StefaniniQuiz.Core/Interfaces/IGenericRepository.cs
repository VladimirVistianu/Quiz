using Microsoft.EntityFrameworkCore.Query;
using StefaniniQuiz.Core.Entities;

namespace StefaniniQuiz.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        Task<ICollection<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<bool> AddAsync(T entity);
        Task<bool> Update(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteAsync(T entity);
        
        //Task EditAsync<T>(Quiz quiz, List<T> questions, List<T> destinations, Action<T, T> cloneItem, Action<T> onDelete = null) ;
        Task<T> GetByIdAsync(Guid id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task<T> SetValues(T existingQuiz, T editedQuiz);
        Task<T> RemoveExistingQuestion(T existingQuestion);





    }
}
