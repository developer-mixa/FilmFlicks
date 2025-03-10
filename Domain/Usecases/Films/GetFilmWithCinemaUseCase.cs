using FilmFlicks.DAL;
using FilmFlicks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmFlicks.Domain.UseCases.Films;

public class GetFilmWithCinemaUseCase(ApplicationDbContext dbContext)
{
    public async Task<FilmEntity?> Execute(long id)
    {
        var film = await dbContext.Films
            .Include(film => film.FilmCinemas)
            .ThenInclude(fc => fc.Tickets)
            .Include(film => film.Cinemas)
            .ThenInclude(cinema => cinema.AddressEntity)
            .FirstOrDefaultAsync(film => film.Id == id);

        return film;
    }
}