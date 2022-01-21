namespace StreamLineTestApi.Data.Repository
{
    public interface IRepository<TEntity> : IRepositoryBase<TEntity>
    {
        public Task<List<TEntity>> GetAll();

        public Task<TEntity?> GetByID(int id);
    }
}
