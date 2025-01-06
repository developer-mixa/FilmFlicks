using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmFlicks.DAL.Repositories;

public class DbFilmRepository(ApplicationDbContext db) : IFilmRepository
{
    public async void Create(Film entity)
    {
        await db.Films.AddAsync(entity);
        await db.SaveChangesAsync();
    }

    public async void Update(Film entity)
    {
        db.Films.Update(entity);
        await db.SaveChangesAsync();
    }

    public async Task<Film?> Get(long id)
    {
        return await db.Films.FirstOrDefaultAsync(x => x != null && x.Id == id);
    }

    public async Task<List<Film?>> Select()
    {
        return await db.Films.ToListAsync();
    }

    public async void Delete(Film entity)
    {
        db.Films.Remove(entity);
        await db.SaveChangesAsync();
    }
}