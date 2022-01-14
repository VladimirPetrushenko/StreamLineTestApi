namespace StreamLineTestApi.Data.Repository
{
    public interface IRepository<TEntity>
    {
        public Task CreateItem(TEntity item);

        public Task DeleteItem(TEntity item);

        public Task<List<TEntity>> GetAll();

        public Task<TEntity?> GetByID(int id);

        public Task UpdateItem(TEntity item);

        public Task<bool> SaveChanges();
    }
}
