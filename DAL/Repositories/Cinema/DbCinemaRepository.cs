using FilmFlicks.DAL.Repositories.Core;
using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmFlicks.DAL.Repositories.Cinema;

public class DbCinemaRepository(ApplicationDbContext db) 
    : CrudRepository<Domain.Entities.CinemaEntity, long>(db, (cinema, id) => cinema.Id == id), ICinemaRepository
{
    public async Task<List<CinemaEntity>> GetCinemasWithAll()
    {
        var r = await db.Cinemas.Include(cinemaEntity => cinemaEntity.AddressEntity).ToListAsync();
        return r;
    }
}