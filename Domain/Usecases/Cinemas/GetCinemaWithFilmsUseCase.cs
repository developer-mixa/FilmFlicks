using FilmFlicks.DAL;
using FilmFlicks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmFlicks.Domain.Usecases.Cinemas;

public class GetCinemaWithFilmsUseCase(ApplicationDbContext dbContext)
{
    public async Task<Cinema?> Execute(long id)
    {
        var film = await dbContext.Cinemas
            .Include(cinema => cinema.Address)
            .Include(cinema => cinema.Films)
            .FirstOrDefaultAsync(cinema => cinema.Id == id);
        return film;
    }
}