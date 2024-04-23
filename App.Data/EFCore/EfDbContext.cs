using Microsoft.EntityFrameworkCore;


namespace App.Data.EFCore;

public class EfDbContext : DbContext
{

    public EfDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        DatabaseInitializer.CreateMigration(modelBuilder);
    }
}
