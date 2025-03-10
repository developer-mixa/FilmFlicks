using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FilmFlicks.Domain.Entities.Core;

namespace FilmFlicks.Domain.Entities;

[Table("films")]
public class FilmEntity : IdEntity
{
    [Column("name")]
    [MaxLength(1024), Required]
    public string Name { get; set; }
    
    [Column("description"), Required]
    public string Description { get; set; }
    
    [Column("rating"), Required]
    [Range(0f, 10f)]
    public float Rating { get; set; }

    public List<CinemaEntity> Cinemas { get; } = [];
    
    public List<FilmCinema> FilmCinemas { get; } = [];

    public override string ToString() => $"name={Name} rating={Rating}";
}