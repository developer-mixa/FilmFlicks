using FilmFlicks.Domain.Usecases.Cinemas;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Pages;

[Route("cinemas")]
public class CinemasPageController(
    GetCinemasUseCase getCinemasUseCase,
    GetCinemaWithFilmsUseCase getCinemaWithFilmsUseCase
) : Controller
{
    
    [Route("")]
    public async Task<IActionResult> Index()
    {
        var films = await getCinemasUseCase.Execute();
        return View(films);
    }

    [Route("{id:long}")]
    public async Task<IActionResult> Details(long id)
    {
        var film = await getCinemaWithFilmsUseCase.Execute(id);
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