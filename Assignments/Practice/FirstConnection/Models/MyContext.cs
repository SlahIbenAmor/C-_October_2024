#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace FirstConnection.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) {}

    // The tables for our database
    public DbSet<Pet> Pets {get;set;}
}
