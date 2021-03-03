using System;
using System.Collections.Generic;
using System.Linq;
using Neoris.Ionleap.Business.Logic.Abstractions.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Adapters.Implementations.Infrastructure;
using Neoris.Ionleap.ResourceAccess.DataBase;
using Neoris.Ionleap.ResourceAccess.Entities.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Neoris.Ionleap.Business.Logic.Implementations.Infrastructure
{
    public class EntityReaderLogic<TEntity, TContext> : BusinessLogicBase, IEntityReaderLogic<TEntity> 
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private IEntityReaderAdapter<TEntity> _entityReaderAdapter;
        protected IEntityReaderAdapter<TEntity> EntityReaderAdapter
        {
            get => _entityReaderAdapter ??= new EntityReaderAdapter<TEntity, TContext>();
        }

        public List<TEntity> GetAll()
        {
            try
            {
                return EntityReaderAdapter.GetAll();
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }

            return null;
        }

        public TEntity Get(int id)
        {
            try
            {
                return EntityReaderAdapter.Get(id);
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }

            return null;
        }

        public TEntity Get(string description)
        {
            try
            {
                return EntityReaderAdapter.Get(description);
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }

            return null;
        }

        public List<TEntity> GetLike(string description)
        {
            try
            {
                return EntityReaderAdapter.GetLike(description);
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }

            return null;
        }
    }
}
