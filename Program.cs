using System.Text;
using DotNetEnv;
using FilmFlicks.DAL;
using FilmFlicks.DAL.Repositories.Address;
using FilmFlicks.DAL.Repositories.Cinema;
using FilmFlicks.DAL.Repositories.Film;
using FilmFlicks.DAL.Repositories.FilmCinema;
using FilmFlicks.DAL.Repositories.Ticket;
using FilmFlicks.DAL.Repositories.User;
using FilmFlicks.Domain;
using FilmFlicks.Domain.Auth;
using FilmFlicks.Domain.Repositories;
using FilmFlicks.Domain.Services;
using FilmFlicks.Domain.Usecases.Cinemas;
using FilmFlicks.Domain.UseCases.Films;
using FilmFlicks.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace FilmFlicks;

public class Program
{
    public static void Main(string[] args)
    {
        Env.Load();
        
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApplicationDbContext>();
        builder.Services.AddHttpContextAccessor();
        
        // Dependencies
        builder.Services.AddScoped<IFilmRepository, DbFilmRepository>();
        builder.Services.AddScoped<GetFilmsUseCase>();
        builder.Services.AddScoped<GetFilmWithCinemaUseCase>();

        builder.Services.AddScoped<ICinemaRepository, DbCinemaRepository>();
        builder.Services.AddScoped<GetCinemasUseCase>();
        builder.Services.AddScoped<GetCinemaWithFilmsUseCase>();

        builder.Services.AddScoped<ITicketRepository, DbTicketRepository>();

        builder.Services.AddScoped<IAddressRepository, DbAddressRepository>();

        builder.Services.AddScoped<IUserRepository, DbUserRepository>();

        builder.Services.AddScoped<IFilmCinemaRepository, DbFilmCinemaRepository>();

        builder.Services.AddScoped<UsersService>();
        
        builder.Services.AddScoped<IJwtProvider, JwtProvider>();
        builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

        // Auth
        builder.Services.AddAuthentication(
            JwtBearerDefaults.AuthenticationScheme
            ).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Envs.GetSecurityKey())                    )
            };

            options.Events = new JwtBearerEvents()
            {
                OnMessageReceived = context =>
                {
                    context.Token = context.Request.Cookies[Envs.GetAuthCookieKey()];

                    return Task.CompletedTask;
                }
            };
        });
        builder.Services.AddAuthorization();
        
        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();
        
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        
        // For security

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}