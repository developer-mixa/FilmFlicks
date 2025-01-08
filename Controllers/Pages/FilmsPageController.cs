using FilmFlicks.Domain.UseCases.Films;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Pages;

[Route("films")]
public class FilmsPageController(
    GetFilmsUseCase getFilmsUseCase,
    GetFilmWithCinemaUseCase getFilmWithCinemaUseCase
) : Controller
{
    [Route("")]
    public async Task<IActionResult> Index()
    {
        var films = await getFilmsUseCase.Execute();
        return View(films);
    }

    [Route("{id:long}")]
    public async Task<IActionResult> Details(long id)
    {
        var film = await getFilmWithCinemaUseCase.Execute(id);
        if (film == null)
        {
            return NotFound();
        }

        return View(film);
    }

    [HttpPost]
    public void BookCinema(long filmId, long cinemaId)
    {
    }
}