using FilmFlicks.DAL.Configurations;
using FilmFlicks.DAL.Options;
using FilmFlicks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FilmFlicks.DAL;

public sealed class ApplicationDbContext : DbContext
{
    
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<CinemaEntity> Cinemas { get; set; }
    public DbSet<FilmEntity> Films { get; set; }
    public DbSet<FilmCinema> FilmCinemas { get; set; }
    public DbSet<TicketEntity> Tickets { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    
    private readonly IOptions<AuthorizationOptions> _authOptions;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IOptions<AuthorizationOptions> authOptions) : base(options)
    {
        _authOptions = authOptions;

        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        
        var connectionString = GetConnectionString();
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new FilmCinemaConfiguration());
        modelBuilder.ApplyConfiguration(new TicketConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new PermissionConfiguration());
        modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(_authOptions.Value));
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