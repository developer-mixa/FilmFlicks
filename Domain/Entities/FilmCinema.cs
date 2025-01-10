using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FilmFlicks.Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;

namespace FilmFlicks.Domain.Entities;

public class FilmCinema : IdEntity
{
    [Column("cinema_id"), Required]
    public long CinemaId { get; set; }
    public CinemaEntity Cinema { get; set; }

    [Column("film_id"), Required]
    public long FilmId { get; set; }
    public FilmEntity Film { get; set; }
    
    public ICollection<TicketEntity> Tickets { get; set; }

    public override string ToString() => $"film={Film} cinema={Cinema}";
}