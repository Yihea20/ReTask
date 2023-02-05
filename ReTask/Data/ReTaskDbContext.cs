using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReTask.Models;

namespace ReTask.Data
{
    public class ReTaskDbContext : IdentityDbContext<User>
    {
        public ReTaskDbContext(DbContextOptions options) : base(options) { }
        public DbSet<News>News {get;set;}
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
