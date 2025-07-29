using Microsoft.EntityFrameworkCore;
using Boekenbeheer.Domain.Entities;

namespace Boekenbeheer.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Boek> Boeken => Set<Boek>();

    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}