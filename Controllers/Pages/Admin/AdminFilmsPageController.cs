using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Pages.Admin;

[Route("admin/films")]
public class AdminFilmsPageController(IFilmRepository filmRepository) : AdminController
{
    
    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var films = await filmRepository.Select();
        return View(films);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateFilm(FilmEntity film)
    {


        await filmRepository.Create(film);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(long id)
    {
        var film = await filmRepository.Get(id);
        if (film == null)
            return NotFound();

        return View(film);
    }

    [HttpPost("edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, FilmEntity film)
    {
        if (id != film.Id)
            return NotFound();

        if (!ModelState.IsValid)
            return View(film);

        await filmRepository.Update(film);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> DeleteView(long id)
    {
        var film = await filmRepository.Get(id);
        if (film == null)
            return NotFound();

        return View(film);
    }

    [HttpPost("delete/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteFilm(long id)
    {
        var film = await filmRepository.Get(id);

        await filmRepository.Delete(film);
        return RedirectToAction(nameof(Index));
    }
}