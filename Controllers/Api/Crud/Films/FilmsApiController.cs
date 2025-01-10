using FilmFlicks.Controllers.Api.Crud.Core;
using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Api.Crud.Films;

[Route("api/films")]
public class FilmsApiController(IFilmRepository filmRepository) : CrudController<FilmEntity>(filmRepository);