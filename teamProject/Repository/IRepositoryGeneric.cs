namespace teamProject.Repository
{
    public interface IRepositoryGeneric<TEntity> where TEntity : class
    {

        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(int id);
        void Save();
    }
}
