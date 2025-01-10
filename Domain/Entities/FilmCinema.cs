using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FilmFlicks.Domain.Entities;

public class FilmCinema : IdEntity
{
    [Column("cinema_id"), Required]
    public long CinemaId { get; set; }
    public Cinema Cinema { get; set; }

    [Column("film_id"), Required]
    public long FilmId { get; set; }
    public Film Film { get; set; }
    
    public ICollection<Ticket> Tickets { get; set; }

    public override string ToString() => $"film={Film} cinema={Cinema}";
}