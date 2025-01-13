using FilmFlicks.DAL.Repositories.Core;
using FilmFlicks.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmFlicks.DAL.Repositories.FilmCinema;

public class DbFilmCinemaRepository(ApplicationDbContext db)
    : CrudRepository<Domain.Entities.FilmCinema, long>(db, (filmCinema, id) => filmCinema.Id == id), IFilmCinemaRepository
{
    public async Task<List<Domain.Entities.FilmCinema>> SelectIncludeAll()
    {
        var filmCinemas = await db.FilmCinemas.Include(filmCinema => filmCinema.Cinema)
            .Include(filmCinema => filmCinema.Film).ToListAsync();

        return filmCinemas;
    }
}