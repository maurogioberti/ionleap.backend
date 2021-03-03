using Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Entities.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Neoris.Ionleap.ResourceAccess.Adapters.Implementations.Infrastructure
{
    public class EntityManagerAdapter<TEntity, TContext> : EntityReaderAdapter<TEntity, TContext>, IEntityManagerAdapter<TEntity>
        where TEntity : class, IEntity
        where TContext: DbContext

    {
        public virtual void Save(TEntity entity)
        {
            using (var context = this.DbContext)
            {
                context.Set<TEntity>().Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                //TODO: Check this https://stackoverflow.com/questions/7642570/saving-changes-updating-existing-object-in-dataset-with-entity-framework-and-not
            }
        }

        public TEntity Add(TEntity entity)
        {
            using (var context = this.DbContext)
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }

            return entity;
        }

        public virtual void Modify(int id, TEntity entity)
        {
            using (var context = this.DbContext)
            {
                context.Set<TEntity>().Update(entity);
                context.SaveChanges();
            }
        }

        public virtual void Remove(int id)
        {
            using (var context = this.DbContext)
            {
                var entity = context.Set<TEntity>().Find(id);
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
