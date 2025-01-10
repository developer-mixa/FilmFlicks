using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FilmFlicks.Domain.Entities.Core;

namespace FilmFlicks.Domain.Entities;

[Table("tickets")]
public class Ticket : IdEntity
{
    [Column("film_time"), Required]
    [DataType("datetime")]
    public DateTime FilmTime { get; set; }
    
    [Column("place"), Required]
    [StringLength(1024)]
    public string Place { get; set; }

    [Column("film_cinema_id")]
    public long FilmCinemaId { get; set; }
    
    public FilmCinema FilmCinema { get; set; }

    [Column("user_id")]
    public long? UserId { get; set; }
    
    public User? User { get; set; }

    public override string ToString() => $"place={Place} filmcinema={FilmCinema}";
}