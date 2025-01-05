using Microsoft.EntityFrameworkCore;

namespace FilmFlicks.DAL;

public sealed class ApplicationDbContext : DbContext
{
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.LogTo(Console.WriteLine);
        
        var connectionString = GetConnectionString();
        optionsBuilder.UseNpgsql(connectionString);
    }


    private static string GetConnectionString()
    {
        var host = Environment.GetEnvironmentVariable("PG_HOST") ?? "127.0.0.1";
        var port = Environment.GetEnvironmentVariable("PG_PORT") ?? "5432";
        var dbName = Environment.GetEnvironmentVariable("PG_DBNAME") ?? "postgres";
        var user = Environment.GetEnvironmentVariable("PG_USER") ?? "postgres";
        var password = Environment.GetEnvironmentVariable("PG_PASSWORD") ?? "postgres";
        
        return $"Server={host}; Port={port}; Database={dbName}; Username={user}; Password={password};";
    }
    
}