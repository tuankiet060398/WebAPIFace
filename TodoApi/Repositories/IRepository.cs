using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TodoApi.Repositories
{
    /// <summary>
    /// IRepository interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Query all.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> QueryAll();

        /// <summary>
        /// Get entity by generic Id.
        /// </summary>
        /// <param name="id"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TId"></typeparam>
        /// <returns></returns>
        T GetById<TId>(TId id);

        /// <summary>
        /// Get entities by a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<T> Where(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Add new entity.
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        // /// <summary>
        // /// Add a collection of entities.
        // /// </summary>
        // /// <param name="entities"></param>
        // void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Update entity.
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        // /// <summary>
        // /// Update a collection of entities.
        // /// </summary>
        // /// <param name="entities"></param>
        // void UpdateRange(IEnumerable<T> entities);

        /// <summary>
        /// Delete entity by Id.
        /// </summary>
        /// <param name="id"></param>
        void Delete<TId>(TId id);

        /// <summary>
        /// Delete entity.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        // /// <summary>
        // /// Delete a collection of entities.
        // /// </summary>
        // /// <param name="entities"></param>
        // void DeleteRange(IEnumerable<T> entities);

        // /// <summary>
        // /// Delete a collection of entities by their entity Ids.
        // /// </summary>
        // /// <param name="entityIds"></param>
        // /// <typeparam name="TId"></typeparam>
        // void DeleteRange<TId>(IEnumerable<TId> entityIds);

        /// <summary>
        /// Save changes.
        /// </summary>
        void SaveChanges();
    }
}
