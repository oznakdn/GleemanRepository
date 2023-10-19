using Example.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.API.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Category> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne<Category>()
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId);
    }
}
