using System.Security.Claims;
using FilmFlicks.Domain.Repositories;
using FilmFlicks.Domain.Usecases.Tickets;
using FilmFlicks.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Pages;

[Route("tickets")]
[Authorize("UserPolicy")]
public class TicketsPageController(GetUserTicketsUseCase getUserTickets, ITicketRepository ticketRepository) : Controller
{
    [Route("")]
    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(CustomClaims.UserId);
        
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized("Пользователь не авторизован");
        }

        try
        {
            var tickets = await getUserTickets.Execute(long.Parse(userId));
            
            if (!tickets.Any())
            {
                ViewBag.Message = "У вас нет купленных билетов";
            }
            else
            {
                ViewBag.Tickets = tickets;
            }

            return View(tickets);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching user tickets: {ex.Message}");
            ViewBag.ErrorMessage = "Произошла ошибка при загрузке ваших билетов";
            return View();
        }
    }
    
    [HttpPost("cancel")]
    public async Task<IActionResult> Cancel(long ticketId, long userId)
    {
        await ticketRepository.CancelForUser(ticketId, userId);
        return RedirectToAction(actionName: "Index");
    }
}