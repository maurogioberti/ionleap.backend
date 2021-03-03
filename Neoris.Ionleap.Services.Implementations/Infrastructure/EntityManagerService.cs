using Neoris.Ionleap.Business.Logic.Abstractions.Infrastructure;
using Neoris.Ionleap.Business.Logic.Implementations.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Entities.Infrastructure;
using Neoris.Ionleap.Services.Abstractions.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace Neoris.Ionleap.Services.Implementations.Infrastructure
{
    public class EntityManagerService<TEntity, TLogic, TContext> : EntityReaderService<TEntity, TLogic, TContext>, IEntityManagerService<TEntity, TLogic>
        where TEntity : BaseEntity
        where TLogic : IEntityManagerLogic<TEntity>
        where TContext : DbContext
    {
        private IEntityManagerLogic<TEntity> _businessLogic;

        public new IEntityManagerLogic<TEntity> BusinessLogic
        {
            get
            {
                if (this._businessLogic == null)
                {
                    this._businessLogic = new EntityManagerLogic<TEntity, TContext>();
                }

                return _businessLogic;
            }
        }

        public void Save(TEntity entity)
        {
            try
            {
                this.BusinessLogic.Save(entity);
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
                return this.BusinessLogic.Add(entity);
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
                this.BusinessLogic.Modify(id, entity);
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
                this.BusinessLogic.Remove(id);
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }
    }
}
