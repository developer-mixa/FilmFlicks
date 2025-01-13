using System.ComponentModel.DataAnnotations;
using FilmFlicks.Domain.Entities;

namespace FilmFlicks.Models;

public class EditTicketViewModel
{
    public long Id { get; set; }
    public long? FilmCinemaId { get; set; }
    
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
    public DateTime FilmTime { get; set; }
    public List<FilmCinema> FilmCinemas { get; set; }
}