using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Pages;

[Route("admin")]
public class AdminPageController : AdminController
{

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }


}