using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FilmFlicks.Controllers.Pages.Admin;

[Route("admin/film-cinema")]
public class AdminFilmCinemasPageController(
    IFilmRepository filmRepository,
    ICinemaRepository cinemaRepository,
    IFilmCinemaRepository filmCinemaRepository
) : AdminController
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var filmCinemas = await filmCinemaRepository.SelectIncludeAll();

        return View(filmCinemas);
    }

    [HttpGet("create")]
    public async Task<IActionResult> Create()
    {
        var films = await filmRepository.Select();
        var cinemas = await cinemaRepository.Select();
    
        ViewBag.Films = new SelectList(films, "Id", "Name");
        ViewBag.Cinemas = new SelectList(cinemas, "Id", "Name");
        
        return View();
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateFilmCinema(FilmCinema filmCinema)
    {
        if (filmCinema.FilmId == 0 || filmCinema.CinemaId == 0)
        {
            ModelState.AddModelError("", "Выберите фильм и киноцентр");
            ViewBag.Films = filmRepository.Select();
            ViewBag.Cinemas = cinemaRepository.Select();
            return RedirectToAction(nameof(Index));
        }
        
        await filmCinemaRepository.Create(filmCinema);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(long id)
    {
        var filmCinema = await filmCinemaRepository.Get(id);
        if (filmCinema == null)
            return NotFound();
        
        var films = await filmRepository.Select();
        var cinemas = await cinemaRepository.Select();
    
        ViewBag.Films = new SelectList(films, "Id", "Name");
        ViewBag.Cinemas = new SelectList(cinemas, "Id", "Name");

        return View(filmCinema);
    }

    [HttpPost("edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditFilmCinema(long id, FilmCinema filmCinema)
    {
        if (id != filmCinema.Id)
            return NotFound();

        if (filmCinema.FilmId == 0 || filmCinema.CinemaId == 0)
        {
            ModelState.AddModelError("", "Выберите фильм и киноцентр");
            ViewBag.Films = await filmRepository.Select();
            ViewBag.Cinemas = await cinemaRepository.Select();
            return RedirectToAction(nameof(Index));
        }

        await filmCinemaRepository.Update(filmCinema);

        return RedirectToAction(nameof(Index));
    }

    
    [HttpPost("delete/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteFilmCinema(long id)
    {
        var filmCinema = await filmCinemaRepository.Get(id);

        if (filmCinema != null) await filmCinemaRepository.Delete(filmCinema);
        
        return RedirectToAction(nameof(Index));
    }
    
}