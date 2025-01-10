using FilmFlicks.DAL.Repositories.Core;
using FilmFlicks.Domain.Entities;

namespace FilmFlicks.Domain.Repositories;

public interface IFilmCinemaRepository : IBaseRepository<FilmCinema, long>;