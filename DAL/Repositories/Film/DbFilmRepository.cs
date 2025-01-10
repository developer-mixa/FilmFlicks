using FilmFlicks.DAL.Repositories.Core;
using FilmFlicks.Domain.Repositories;

namespace FilmFlicks.DAL.Repositories.Film;

public class DbFilmRepository(ApplicationDbContext db)
    : CrudRepository<Domain.Entities.FilmEntity, long>(db, (film, id) => film.Id == id), IFilmRepository;