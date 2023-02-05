using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ReTask.IRepository
{
    public interface IGenericRepository<T> where T:class
    {

        Task<IList<T>> GetAll();
        Task<T> Get(Expression<Func<T, bool>> expression);
        Task Insert(T entity);
        Task Delete(int id);
        void Update(T entity);
    }
}
