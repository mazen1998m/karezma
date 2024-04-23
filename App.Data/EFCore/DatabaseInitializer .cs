using app.core.EntityAndDtoStructure.EntityStructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App.Data.EFCore;

public static class DatabaseInitializer
{


    public static void CreateMigration(ModelBuilder builder)
    {
        var assembly = Assembly.GetAssembly(typeof(App.Domain.Users.User));
        var types = assembly?.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Entity)));
        if (types == null) return;
        foreach (var type in types)
        {
            var configType = type.GetNestedType("Configuration", BindingFlags.NonPublic);

            if (configType is not { IsClass: true }) continue;
            var config = Activator.CreateInstance(configType);
            builder.ApplyConfiguration(config as dynamic);
        }
    }


    public static void Initializer(EfDbContext dbContext)
    {
        ModelBuilder modelBuilder = new();
        var assembly = Assembly.GetExecutingAssembly();
        var types = assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Entity)));
        foreach (var type in types)
        {
            modelBuilder.Entity(type);
        }
        modelBuilder.Model.FinalizeModel();
        dbContext.Database.Migrate();
    }
}