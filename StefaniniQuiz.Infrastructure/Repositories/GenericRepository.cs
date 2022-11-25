using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using StefaniniQuiz.Core.Entities;
using StefaniniQuiz.Core.Interfaces;
using StefaniniQuiz.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
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

  
        public async Task<bool> Update(T entity)
        {
           
                _quizDbContext.Update(entity);
                await _quizDbContext.SaveChangesAsync();
               return true;
            
        }

        public async Task<ICollection<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {

             IQueryable<T> query = _dbSet;

            if (include != null)
            {
                query = include(query);
            }

            return await query.ToListAsync();
        }

       

        public async Task<T?> GetByIdAsync(Guid id,Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null )
        {
            IQueryable<T> query = _dbSet;
            

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync(t => t.Id == id);


        }

        public  async Task<T> RemoveExistingQuestion(T existingQuestion)
        {
            _dbSet.Remove(existingQuestion);
            return existingQuestion;
           
        }

        public async Task<T> SetValues(T existingEntity, T editedEntity)
        {
            _quizDbContext.Entry(existingEntity).CurrentValues.SetValues(editedEntity);
            return existingEntity;
        }

        //protected void SynchronizeCollection(
        //    List<T> sources,
        //    List<T> destinations,
        //    Action<T, T> cloneItem,
        //    Action<T> onDelete = null)
        //{
        //    //sources = sources.EmptyIfNull();

        //    var sourceIds = sources.Select(source => source.Id).ToList();

        //    // delete
        //    var deletedItems = destinations
        //        .Where(destination => !sourceIds.Contains(destination.Id))
        //        .ToList();

        //    foreach (var toDelete in deletedItems)
        //    {
        //        onDelete?.Invoke(toDelete);

        //        destinations.Remove(toDelete);

        //        if (//!IsReadOnly && 
        //             toDelete.Id != Guid.Empty)
        //            _dbSet.Remove(toDelete);
        //    }

        //    // update
        //    var editedSourceItems = sources
        //        .Where(source => destinations
        //            .SingleOrDefault(destination => destination.Id == source.Id) != null);
        //    foreach (var toEdit in editedSourceItems)
        //    {
        //        var destination = destinations.Single(d => d.Id == toEdit.Id);

        //        cloneItem(toEdit, destination);

        //        if (//!IsReadOnly  && 
        //            destination.Id != Guid.Empty)
        //            _dbSet.Update(destination);
        //    }

        //    // insert
        //    var newSourceItems = sources
        //        .Where(source => destinations
        //            .SingleOrDefault(destination => destination.Id == source.Id && source.Id != Guid.Empty) == null);

        //    foreach (var toInsert in newSourceItems)
        //    {
        //        var destination = new T();

        //        cloneItem(toInsert, destination);

        //        destinations.Add(destination);

        //    }

    }
}

