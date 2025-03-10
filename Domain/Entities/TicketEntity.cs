using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FilmFlicks.Domain.Entities.Core;

namespace FilmFlicks.Domain.Entities;

[Table("tickets")]
public class TicketEntity : IdEntity
{
    [Column("film_time"), Required]
    [DataType("datetime")]
    public DateTime FilmTime { get; set; }
    
    [Column("film_cinema_id")]
    public long FilmCinemaId { get; set; }
    
    public FilmCinema FilmCinema { get; set; }

    [Column("user_id")]
    public long? UserId { get; set; }
    
    public UserEntity? User { get; set; }

    public override string ToString() => $"filmcinema={FilmCinema}";
}