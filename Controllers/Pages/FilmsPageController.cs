using FilmFlicks.Controllers.Pages.Base;
using FilmFlicks.Domain.Repositories;
using FilmFlicks.Domain.UseCases.Films;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Pages;

[Route("films")]
public class FilmsPageController(
    GetFilmsUseCase getFilmsUseCase,
    GetFilmWithCinemaUseCase getFilmWithCinemaUseCase,
    ITicketRepository ticketRepository
) : BookController(ticketRepository)
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
    
}