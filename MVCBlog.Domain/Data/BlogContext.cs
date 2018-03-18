using Microsoft.EntityFrameworkCore;

namespace MVCBlog.Domain.Data
{
    class BlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-P6NLD0E;Initial Catalog=localDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configuration.EssayConfig());
        }
    }
}
