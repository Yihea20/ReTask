using ReTask.Models;

namespace ReTask.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        public IGenericRepository<News> News { get;}
        Task Save();
    }
}
