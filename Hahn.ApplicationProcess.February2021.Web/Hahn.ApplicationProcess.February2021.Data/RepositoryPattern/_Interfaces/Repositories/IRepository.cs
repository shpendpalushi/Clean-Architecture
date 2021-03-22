using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Data.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Getting the the entity specified by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(int id);

        /// <summary>
        /// Getting all entities, since it is not required 
        /// we might throw an UnImplementedException
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Returns the only element of a sequence, 
        /// or a default value if the sequence is empty; 
        /// this method throws an exception if there is more than one element in the sequence.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        
        /// <summary>
        /// Adding a new Entity
        /// </summary>
        /// <param name="entity"></param>
        TEntity Add(TEntity entity);
        void Edit(TEntity entity);

        /// <summary>
        /// Delete the found entity
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);

        /// <summary>
        /// Remove the entity by its id
        /// </summary>
        /// <param name="id"></param>
        void RemoveById(int id);
    }
}
