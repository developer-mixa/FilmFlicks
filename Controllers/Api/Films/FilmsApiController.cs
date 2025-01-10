using FilmFlicks.Controllers.Api.Core;
using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Api.Films;

[Route("api/films")]
public class FilmsApiController(IFilmRepository filmRepository) : CrudController<Film>(filmRepository);