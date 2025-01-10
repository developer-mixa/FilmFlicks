using FilmFlicks.DAL.Repositories.Core;
using FilmFlicks.Domain.Repositories;

namespace FilmFlicks.DAL.Repositories.FilmCinema;

public class DbFilmCinemaRepository(ApplicationDbContext db)
    : CrudRepository<Domain.Entities.FilmCinema, long>(db, (filmCinema, id) => filmCinema.Id == id), IFilmCinemaRepository;