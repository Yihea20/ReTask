using ReTask.Data;
using ReTask.IRepository;
using ReTask.Models;

namespace ReTask.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ReTaskDbContext _context;
        private  IGenericRepository<News> _news;

        public UnitOfWork(ReTaskDbContext context)
        {
            _context = context;

        }
       // public IGenericRepository<News> Newses => _newses ??= new GenericRepository<News>(_context);

        public IGenericRepository<News> News => _news ??= new GenericRepository<News>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
