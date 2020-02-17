using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Repositories
{
    /// <summary>
    /// Generic repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// DbContext.
        /// </summary>
        protected DbContext DbContext { get; }

        /// <summary>
        /// DbSet.
        /// </summary>
        protected DbSet<T> DbSet { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dbContext"></param>
        public Repository(DbContext dbContext)
        {
            this.DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.DbSet = dbContext.Set<T>();
        }

        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll() => this.DbSet;

        /// <summary>
        /// Query all entities.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> QueryAll() => this.DbSet;

        /// <summary>
        /// Get entity by generic Id.
        /// </summary>
        /// <param name="id"></param>
        /// <typeparam name="TId"></typeparam>
        /// <returns></returns>
        public virtual T GetById<TId>(TId id) => this.DbSet.Find(id);

        /// <summary>
        /// Get entities by a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> Where(Expression<Func<T, bool>> predicate) => this.QueryAll().Where(predicate);

        /// <summary>
        /// Add new entity.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(T entity)
        {
            var dbEntityEntry = this.DbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        // /// <summary>
        // /// Add a collection of entities.
        // /// </summary>
        // /// <param name="entities"></param>
        // public virtual void AddRange(IEnumerable<T> entities) => entities.ForEach(this.Add);

        /// <summary>
        /// Update entity.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            var dbEntityEntry = this.DbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            dbEntityEntry.State = EntityState.Modified;
        }

        // /// <summary>
        // /// Update a collection of entities.
        // /// </summary>
        // /// <param name="entities"></param>
        // public virtual void UpdateRange(IEnumerable<T> entities) => entities.ForEach(this.Update);

        /// <summary>
        /// Delete entity.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            var dbEntityEntry = this.DbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        /// <summary>
        /// Delete entity by Id.
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete<TId>(TId id)
        {
            var entity = this.GetById(id);
            if (entity == null)
            {
                return;
            }

            this.Delete(entity);
        }

        // /// <summary>
        // /// Delete a collection of entities.
        // /// </summary>
        // /// <param name="entities"></param>
        // public virtual void DeleteRange(IEnumerable<T> entities) => entities.ForEach(this.Delete);

        // /// <summary>
        // /// Delete a collection of entities by their entity Ids.
        // /// </summary>
        // /// <param name="entityIds"></param>
        // /// <typeparam name="TId"></typeparam>
        // public virtual void DeleteRange<TId>(IEnumerable<TId> entityIds) => entityIds.ForEach(this.Delete);

        /// <summary>
        /// Save changes.
        /// </summary>
        public virtual void SaveChanges() => this.DbContext.SaveChanges();

        /// <summary>
        /// Reset DB context.
        /// </summary>
        protected void ResetContextState() => this.DbContext.ChangeTracker.Entries()
            .Where(e => e.Entity != null).ToList()
            .ForEach(e => e.State = EntityState.Detached);
    }
}
