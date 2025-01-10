using FilmFlicks.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Pages.Base;

public class BookController(ITicketRepository ticketRepository) : Controller
{
    [HttpPost("book")]
    public async Task<IActionResult> Book(long ticketId, long userId)
    {
        await ticketRepository.BookForUser(ticketId, userId);
        return RedirectToAction(actionName: "Index", controllerName:"Home");
    }
}