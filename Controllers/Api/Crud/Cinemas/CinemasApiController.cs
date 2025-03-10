using FilmFlicks.Controllers.Api.Crud.Core;
using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Api.Crud.Cinemas;

[Route("api/cinemas")]
public class CinemasApiController(ICinemaRepository cinemaRepository) : CrudController<CinemaEntity>(cinemaRepository);