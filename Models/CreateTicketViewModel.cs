using FilmFlicks.Domain.Entities;

namespace FilmFlicks.Models;

public class CreateTicketViewModel
{
    public long? FilmCinemaId { get; set; }
    public DateTime FilmTime { get; set; }
    public List<FilmCinema> FilmCinemas { get; set; } = [];
}