using Microsoft.EntityFrameworkCore;
using RpgTrade.Domain;

namespace RpgTrade.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Item> Items => Set<Item>();
    public DbSet<ItemModifier> ItemModifiers => Set<ItemModifier>();
    public DbSet<ModifierDefinition> ModifierDefinitions => Set<ModifierDefinition>();
    public DbSet<BaseType> BaseTypes => Set<BaseType>();
    public DbSet<ItemClass> ItemClasses => Set<ItemClass>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}