using FilmFlicks.Controllers.Api.Core;
using FilmFlicks.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Api.FilmCinema;

[Route("api/filmCinemas")]
public class FilmCinemaApiController(IFilmCinemaRepository filmCinemaRepository)
    : CrudController<Domain.Entities.FilmCinema>(filmCinemaRepository);