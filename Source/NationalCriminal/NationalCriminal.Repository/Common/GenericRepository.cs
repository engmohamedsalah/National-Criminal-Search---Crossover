using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NationalCriminal.DAL;
using System.Data.Linq;

namespace NationalCriminal.Repository
{
    /// <summary>
    /// this is generic Generic Repository for All Entities in the system
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="NationalCriminal.Repository.IGenericRepository{T}" />
    public abstract class GenericRepository<T> : IGenericRepository<T>
       where T : class
    {
        protected NationalCriminalDataContext _dataContextFactory;
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        public GenericRepository()
        {
            if (_dataContextFactory == null)
                _dataContextFactory = new NationalCriminalDataContext();
        }
        /// <summary>
        /// Return all instances of type T.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> All()
        {
            return GetTable;
        }

        /// <summary>
        /// Return all instances of type T that match the expression exp.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public IEnumerable<T> FindAll(Func<T, bool> exp)
        {
            return GetTable.Where<T>(exp);
        }

        /// <summary>See IGenericRepository.</summary>
        /// <param name="exp"></param><returns></returns>
        public T Single(Func<T, bool> exp)
        {
            return GetTable.Single(exp);
        }

        /// <summary>See IGenericRepository.</summary>
        /// <param name="exp"></param><returns></returns>
        public T First(Func<T, bool> exp)
        {
            return GetTable.First(exp);
        }

        /// <summary>See IGenericRepository.</summary>
        /// <param name="entity"></param>
        public virtual void MarkForDeletion(T entity)
        {
            _dataContextFactory.GetTable<T>().DeleteOnSubmit(entity);
        }

        /// <summary>
        /// Create a new instance of type T.
        /// </summary>
        /// <returns></returns>
        public virtual T CreateInstance()
        {
            T entity = Activator.CreateInstance <T> ();
            GetTable.InsertOnSubmit(entity);
            return entity;
        }

        /// <summary>See IGenericRepository.</summary>
        public void SaveAll()
        {
            _dataContextFactory.SubmitChanges();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> IGenericRepository<T>.GetAll()
        {
           return _dataContextFactory.GetTable<T>().ToList();
        }

        /// <summary>
        /// Finds the by.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        IEnumerable<T> IGenericRepository<T>.FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dataContextFactory.GetTable<T>().Where(predicate);
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        T IGenericRepository<T>.Add(T entity)
        {
            _dataContextFactory.GetTable<T>().InsertOnSubmit(entity);
            return entity;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void IGenericRepository<T>.Delete(T entity)
        {
            _dataContextFactory.GetTable<T>().DeleteOnSubmit(entity);
        }

        /// <summary>
        /// Edits the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        void IGenericRepository<T>.Edit(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void IGenericRepository<T>.Save()
        {
            _dataContextFactory.SubmitChanges();
        }

        /// <summary>
        /// Deletes the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        public void Delete(Expression<Func<T, bool>> predicate)
        {
            var entities = _dataContextFactory.GetTable<T>().Where(predicate);
            _dataContextFactory.GetTable<T>().DeleteAllOnSubmit(entities);
        }



        #region Properties

        /// <summary>
        /// Gets the name of the primary key.
        /// </summary>
        /// <value>
        /// The name of the primary key.
        /// </value>
        private string PrimaryKeyName
        {
            get { return TableMetadata.RowType.IdentityMembers[0].Name; }
        }

        /// <summary>
        /// Gets the get table.
        /// </summary>
        /// <value>
        /// The get table.
        /// </value>
        private System.Data.Linq.Table<T> GetTable
        {
            get { return _dataContextFactory.GetTable<T>(); }
        }

        /// <summary>
        /// Gets the table metadata.
        /// </summary>
        /// <value>
        /// The table metadata.
        /// </value>
        private System.Data.Linq.Mapping.MetaTable TableMetadata
        {
            get { return _dataContextFactory.Mapping.GetTable(typeof(T)); }
        }

        /// <summary>
        /// Gets the class metadata.
        /// </summary>
        /// <value>
        /// The class metadata.
        /// </value>
        private System.Data.Linq.Mapping.MetaType ClassMetadata
        {
            get { return _dataContextFactory.Mapping.GetMetaType(typeof(T)); }
        }

        #endregion
    }
}
