using Microsoft.EntityFrameworkCore;
using PlainMinimalApi.Entities;

namespace PlainMinimalApi.Context;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(u => u.Email);
    }
}