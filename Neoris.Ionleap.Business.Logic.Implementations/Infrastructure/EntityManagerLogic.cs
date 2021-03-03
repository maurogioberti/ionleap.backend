using Neoris.Ionleap.Business.Logic.Abstractions.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Adapters.Implementations.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Entities.Infrastructure;
using System;
using System.Runtime.CompilerServices;
using Neoris.Ionleap.ResourceAccess.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Neoris.Ionleap.Business.Logic.Implementations.Infrastructure
{
    public class EntityManagerLogic<TEntity, TContext> : EntityReaderLogic<TEntity, TContext>, IEntityManagerLogic<TEntity> 
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private IEntityManagerAdapter<TEntity> _entityManagerAdapter;
        protected IEntityManagerAdapter<TEntity> EntityManagerAdapter
        {
            get => _entityManagerAdapter ??= new EntityManagerAdapter<TEntity, TContext>();
        }

        public void Save(TEntity entity)
        {
            try
            {
                this.EntityManagerAdapter.Save(entity);
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public TEntity Add(TEntity entity)
        {
            try
            {
                return this.EntityManagerAdapter.Add(entity);
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }

            return null;
        }

        public void Modify(int id, TEntity entity)
        {
            try
            {
                this.EntityManagerAdapter.Modify(id, entity);
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public void Remove(int id)
        {
            try
            {
                this.EntityManagerAdapter.Remove(id);
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }
    }
}
