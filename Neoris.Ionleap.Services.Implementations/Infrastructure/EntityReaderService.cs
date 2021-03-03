using Neoris.Ionleap.Business.Logic.Abstractions.Infrastructure;
using Neoris.Ionleap.Business.Logic.Implementations.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Entities.Infrastructure;
using Neoris.Ionleap.Services.Abstractions.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Neoris.Ionleap.Services.Implementations.Infrastructure
{
    public class EntityReaderService<TEntity, TLogic, TContext> : ServiceBase, IEntityReaderService<TEntity, TLogic> 
        where TEntity : BaseEntity
        where TLogic : IEntityReaderLogic<TEntity>
        where TContext : DbContext
    {
        private IEntityReaderLogic<TEntity> _businessLogic;

        public IEntityReaderLogic<TEntity> BusinessLogic
        {
            get
            {
                if (this._businessLogic == null)
                {
                    this._businessLogic = new EntityReaderLogic<TEntity, TContext>();
                }

                return _businessLogic;
            }
        }

        public List<TEntity> GetAll()
        {
            try
            {
                return this.BusinessLogic.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public TEntity Get(int id)
        {
            try
            {
                return this.BusinessLogic.Get(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public TEntity Get(string description)
        {
            try
            {
                return this.BusinessLogic.Get(description);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public List<TEntity> GetLike(string description)
        {
            try
            {
                return this.BusinessLogic.GetLike(description);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }
    }
}