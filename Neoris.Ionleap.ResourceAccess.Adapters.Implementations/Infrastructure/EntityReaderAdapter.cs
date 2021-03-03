using Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Entities.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Neoris.Ionleap.ResourceAccess.Adapters.Implementations.Infrastructure
{
    public class EntityReaderAdapter<TEntity, TContext> : IEntityReaderAdapter<TEntity> 
        where TEntity : class, IEntity
        where TContext : DbContext, IDisposable
    {
        //It's a good practice to use DbContext per each request. Your context disposed automatically at the end of your request in general
        private DbContext _dbContext;
        protected DbContext DbContext
        {
            get 
            {
                if (_dbContext != default)
                    _dbContext.Dispose();
                
                _dbContext = (TContext)Activator.CreateInstance(typeof(TContext));

                return _dbContext; 
            }
        }

        public virtual List<TEntity> GetAll()
        {
            using (var context = this.DbContext)
            {
                return context.Set<TEntity>().AsNoTracking().ToList();
            }
        }

        public virtual TEntity Get(int id)
        {
            using (var context = this.DbContext)
            {
                return context.Set<TEntity>()
                    .AsNoTracking()
                    .First(e => e.Identity == id);
            }
        }

        public virtual TEntity Get(string description)
        {
            using (var context = this.DbContext)
            {
                return context.Set<TEntity>()
                    .AsNoTracking()
                    .First(e => e.Description == description);
            }
        }

        public virtual List<TEntity> GetLike(string description)
        {
            string[] descriptions = description.Split(" ");
            List<TEntity> likes = new List<TEntity>();
            using (var context = this.DbContext)
            {
                foreach(string desc in descriptions)
                {
                    likes.AddRange(
                                    context.Set<TEntity>()
                                    .AsNoTracking()
                                    .Where(e => e.Description.ToLower().Contains(desc.ToLower())).ToList()
                                    );
                }
            }

            return likes;
        }
    }
}
