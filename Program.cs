using DotNetEnv;
using FilmFlicks.DAL;
using FilmFlicks.DAL.Repositories;
using FilmFlicks.DAL.Repositories.Cinema;
using FilmFlicks.DAL.Repositories.Film;
using FilmFlicks.Domain.Repositories;
using FilmFlicks.Domain.Usecases.Cinemas;
using FilmFlicks.Domain.UseCases.Films;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace FilmFlicks;

public class Program
{
    public static void Main(string[] args)
    {
        Env.Load();
        
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApplicationDbContext>();
        
        // Dependencies
        builder.Services.AddScoped<IFilmRepository, DbFilmRepository>();
        builder.Services.AddScoped<GetFilmsUseCase>();
        builder.Services.AddScoped<GetFilmWithCinemaUseCase>();

        builder.Services.AddScoped<ICinemaRepository, DbCinemaRepository>();
        builder.Services.AddScoped<GetCinemasUseCase>();
        builder.Services.AddScoped<GetCinemaWithFilmsUseCase>();

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

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}