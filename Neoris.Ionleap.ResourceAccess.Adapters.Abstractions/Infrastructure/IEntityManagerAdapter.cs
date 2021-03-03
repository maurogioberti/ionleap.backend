namespace Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Infrastructure
{
    public interface IEntityManagerAdapter<TEntity> : IEntityReaderAdapter<TEntity> where TEntity : class
    {
        void Save(TEntity entity);

        TEntity Add(TEntity entity);

        void Modify(int id, TEntity entity);

        void Remove(int id);
    }
}
