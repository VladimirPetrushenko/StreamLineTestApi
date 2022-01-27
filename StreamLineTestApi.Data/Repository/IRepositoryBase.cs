namespace StreamLineTestApi.Data.Repository
{
    public interface IRepositoryBase<TEntity>
    {
        public Task<TEntity> CreateItem(TEntity item);

        public Task DeleteItem(TEntity item);

        public Task UpdateItem(TEntity item);

        public Task<bool> SaveChanges();
    }
}
