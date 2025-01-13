using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;
using FilmFlicks.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Pages.Admin;


[Route("admin/tickets")]
public class AdminTicketsPageController(
    ITicketRepository ticketRepository,
    IFilmCinemaRepository filmCinemaRepository
) : AdminController
{
        
    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var tickets = await ticketRepository.SelectTicketsIncludeAll();
        return View(tickets);
    }

    [HttpGet("create")]
    public async Task<IActionResult> Create()
    {
        var viewModel = new CreateTicketViewModel { FilmCinemas = await filmCinemaRepository.SelectIncludeAll() };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateTicketPost(CreateTicketViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            await ticketRepository.Create(new TicketEntity()
            {
                FilmTime = viewModel.FilmTime.ToUniversalTime(),
                FilmCinemaId = viewModel.FilmCinemaId.Value
                
            });
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(long id)
    {
        var ticket = await ticketRepository.Get(id);
        if (ticket == null)
            return NotFound();

        var viewModel = new EditTicketViewModel
        {
            Id = ticket.Id,
            FilmCinemaId = ticket.FilmCinemaId,
            FilmTime = ticket.FilmTime,
            FilmCinemas = await filmCinemaRepository.SelectIncludeAll()
        };

        return View(viewModel);
    }
    
    
    [HttpPost("edit")]
    public async Task<IActionResult> EditTicketPost(EditTicketViewModel viewModel)
    {
        var ticket = await ticketRepository.Get(viewModel.Id);

        if (ticket == null)
        {
            return NotFound();
        }
        
        ticket.FilmCinemaId = viewModel.FilmCinemaId ?? 0;
        ticket.FilmTime = viewModel.FilmTime.ToUniversalTime();

        await ticketRepository.Update(ticket);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost("delete/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(long id)
    {
        var ticket = await ticketRepository.Get(id);
        
        if (ticket == null)
            return NotFound();

        await ticketRepository.Delete(ticket);

        return RedirectToAction(nameof(Index));
    }

}