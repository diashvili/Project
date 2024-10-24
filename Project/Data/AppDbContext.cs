using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //     optionsBuilder.UseSqlServer("Server=iashka;Database=Project;Integrated Security=True;TrustServerCertificate=True;");
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId);

            //modelBuilder.Entity<User>().HasData(new User { UserId = 1, Name = "data", Email = "data@gmail.com" });
            //modelBuilder.Entity<Post>().HasData(new Post { PostId = 1, Title = "Hello World", Content = "First post", UserId = 1 });
        }
    }
}
