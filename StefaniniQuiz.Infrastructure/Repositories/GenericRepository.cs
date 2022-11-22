using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StefaniniQuiz.Core.Interfaces;
using StefaniniQuiz.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly QuizDbContext _quizDbContext;
        protected DbSet<T> _dbSet;

        public GenericRepository(QuizDbContext quizDbContext)
        {
            _quizDbContext = quizDbContext;
            _dbSet = _quizDbContext.Set<T>();
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _quizDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var toDelete = await _dbSet.FindAsync(id);

                return await DeleteAsync(toDelete);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                await _quizDbContext.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> EditAsync(T entity)
        {
            try
            {
                _quizDbContext.Update(entity);
                await _quizDbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
