using FilmFlicks.DAL.Repositories.Core;
using FilmFlicks.Domain.Repositories;

namespace FilmFlicks.DAL.Repositories.Cinema;

public class DbCinemaRepository(ApplicationDbContext db) 
    : CrudRepository<Domain.Entities.CinemaEntity, long>(db, (cinema, id) => cinema.Id == id), ICinemaRepository;