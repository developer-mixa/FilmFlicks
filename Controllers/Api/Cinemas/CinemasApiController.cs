using FilmFlicks.Controllers.Api.Core;
using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Api.Cinemas;

[Route("api/cinemas")]
public class CinemasApiController(ICinemaRepository cinemaRepository) : CrudController<Cinema>(cinemaRepository);