namespace SIEPRO.API.Infrastructure.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(string id);
        T Add(T entity);
        T Update(string id, T entity);
        void Remove(string id);
    }
}
