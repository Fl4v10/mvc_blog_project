using Microsoft.EntityFrameworkCore;

namespace MVCBlog.Domain.Data
{
    public class BlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-P6NLD0E;Initial Catalog=localDB;Integrated Security=True;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configuration.EssayConfig());
        }

        public DbSet<Entities.Essay> Essays { get; set; }
    }
}
