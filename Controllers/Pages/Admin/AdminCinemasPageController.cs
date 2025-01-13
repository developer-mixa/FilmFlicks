using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Pages.Admin;

[Route("admin/cinemas")]
public class AdminCinemasPageController(ICinemaRepository cinemaRepository) : AdminController
{
    
    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var cinemas = await cinemaRepository.GetCinemasWithAll();
        if (!cinemas.Any())
        {
            ViewBag.NoCinemasMessage = "Нет кинотеатров.";
            return View(ViewBag);
        }
        return View(cinemas);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        var cinema = new CinemaEntity();
        return View(cinema);
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CinemaEntity cinema)
    {
        if (!ModelState.IsValid)
            return View(cinema);

        await cinemaRepository.Create(cinema);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(long id)
    {
        var cinema = await cinemaRepository.Get(id);
        if (cinema == null)
            return NotFound();

        return View(cinema);
    }

    [HttpPost("edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, CinemaEntity cinema)
    {
        if (id != cinema.Id)
            return NotFound();

        if (!ModelState.IsValid)
            return View(cinema);

        await cinemaRepository.Update(cinema);
        return RedirectToAction(nameof(Index));
    }

    /*[HttpGet("delete/{id}")]
    public async Task<IActionResult> DeleteView(long id)
    {
        var cinema = await cinemaRepository.Get(id);
        if (cinema == null)
            return NotFound();

        return View(cinema);
    }*/

    [HttpPost("delete/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(long id)
    {
        var cinema = await cinemaRepository.Get(id);
        if (cinema == null)
            return NotFound();

        await cinemaRepository.Delete(cinema);
        return RedirectToAction(nameof(Index));
    }
}