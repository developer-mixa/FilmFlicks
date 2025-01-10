using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Pages;

[Route("tickets")]
public class TicketsPageController : Controller
{
    [Route("")]
    public async Task<IActionResult> Index()
    {
        return View();
    }
}