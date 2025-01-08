using FilmFlicks.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Pages;

[Route("films")]
public class FilmsPageController(IFilmRepository filmRepository) : Controller
{
    
    [Route("")]
    public async Task<IActionResult> Index()
    {
        var films = await filmRepository.Select();
        return View(films);
    }
    
}