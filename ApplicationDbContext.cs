using Microsoft.EntityFrameworkCore;
using TestApi.Models;

namespace TestApi;

public class ApplicationDbContext : DbContext
{
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Comment>? Comments { get; set; } 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>().HasData(
            new Comment
            {
                Id = 1,
                Title = "Holi",
                Description = "Descripción UwU",
                Author = "Ricardo C.",
                CreatedAt = DateTime.Now
            },
            new Comment
            {
                Id = 2,
                Title = "Foo",
                Description = "Bar",
                Author = "Ricardo C.",
                CreatedAt = DateTime.Now
            },
            new Comment
            {
                Id = 3,
                Title = "Causa pe",
                Description = "l wea fme wn",
                Author = "Ricardo C.",
                CreatedAt = DateTime.Now
            }
        );
    }
    
}