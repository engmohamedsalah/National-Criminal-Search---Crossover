using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace NationalCriminal.Repository
{
    /// <summary>
    /// this is interface for IGenericRepository class 
    /// contains the essential methods
    /// </summary>
    /// <typeparam name="T"> is general class </typeparam>
    public interface IGenericRepository<T> where T : class
    {

        //return all data
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        //search by predicate condition
        /// <summary>
        /// Finds the by.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        //add new entity
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        T Add(T entity);
        //delete entity
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);
        //delete entity or entities that match the condition
        /// <summary>
        /// Deletes the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        void Delete(Expression<Func<T, bool>> predicate);
        //update entity
        /// <summary>
        /// Edits the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Edit(T entity);
        //save context
        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();
    }
}
