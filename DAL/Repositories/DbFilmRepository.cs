using FilmFlicks.DAL.Repositories.Core;
using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;

namespace FilmFlicks.DAL.Repositories;

public class DbFilmRepository(ApplicationDbContext db)
    : CrudRepository<Film, long>(db, (film, id) => film.Id == id), IFilmRepository;