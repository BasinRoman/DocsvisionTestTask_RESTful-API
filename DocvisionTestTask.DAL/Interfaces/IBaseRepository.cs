namespace DocvisionTestTask.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);
        IEnumerable<T> Select();
    }
}
