using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ReTask.Data;
using ReTask.IRepository;
using System.Linq.Expressions;

namespace ReTask.Repository
{
    public class GenericRepository<T>:IGenericRepository<T> where T:class
    {
        private readonly ReTaskDbContext _context;
        private readonly DbSet<T> _db;
        public GenericRepository(ReTaskDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        
        public async Task<T> Get(Expression<Func<T, bool>> expression
            )
        {
            IQueryable<T> query = _db;
            
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll()
        {
            IQueryable<T> query = _db;
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);

        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
