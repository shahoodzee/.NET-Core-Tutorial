using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using MyStore.Api.Entities;
namespace MyStore.Api.Data;

public class MyStoreContext(DbContextOptions<MyStoreContext> options) 
    : DbContext(options)
{

    /*

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Item>().ToCollection("Item");
    }

    */

    public DbSet<Item> Items => Set<Item>();
    public DbSet<ItemType> ItemTypes => Set<ItemType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemType>().HasData(
            new { Id = 1, Name = "Game" },
            new { Id = 2, Name = "Movie" },
            new { Id = 3, Name = "SportsItem" },
            new { Id = 4, Name = "Food" },
            new { Id = 5, Name = "Electronics" }
        );
    }
}

// in order to create a conn btw EF and nosql DB like MongoDb
// you need to override create method present in Dbcontext class 