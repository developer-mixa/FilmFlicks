using FilmFlicks.Controllers.Api.Crud.Core;
using FilmFlicks.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Api.Crud.FilmCinema;

[Route("api/filmCinemas")]
public class FilmCinemaApiController(IFilmCinemaRepository filmCinemaRepository)
    : CrudController<Domain.Entities.FilmCinema>(filmCinemaRepository);