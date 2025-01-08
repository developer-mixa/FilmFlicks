using FilmFlicks.Domain.UseCases.Films;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Pages;

[Route("films")]
public class FilmsPageController(GetFilmsUseCase getFilmsUseCase) : Controller
{
    
    [Route("")]
    public async Task<IActionResult> Index()
    {
        var films = await getFilmsUseCase.Execute();
        return View(films);
    }
    
}