using FilmFlicks.DAL.Configurations;
using FilmFlicks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmFlicks.DAL;

public sealed class ApplicationDbContext : DbContext
{
    
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Film?> Films { get; set; }
    public DbSet<FilmCinema> FilmCinemas { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<User> Users { get; set; }
    
    
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new FilmCinemaConfiguration());
        modelBuilder.ApplyConfiguration(new CinemaConfiguration());
        modelBuilder.ApplyConfiguration(new FilmConfiguration());
        modelBuilder.ApplyConfiguration(new TicketConfiguration());
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