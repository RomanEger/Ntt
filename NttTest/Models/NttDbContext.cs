using Microsoft.EntityFrameworkCore;

namespace NttTest.Models;

public class NttDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public NttDbContext(DbContextOptions<NttDbContext> options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.LogTo(Console.WriteLine);
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var category = new Category
        {
            Id = 1,
            Name = "Посуда"
        };
        modelBuilder.Entity<Category>().HasData(category);
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = 2,
            Name = "Мебель"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 1,
            Title = "Тарелка белая",
            Price = 99.99m,
            Quantity = 10,
            CategoryId = category.Id
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 2,
            Title = "Кружка",
            Description = "Кружка чайная",
            Price = 150,
            Quantity = 3,
            CategoryId = category.Id
        });
    }
}