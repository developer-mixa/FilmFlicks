using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FilmFlicks.Domain.Entities.Core;

namespace FilmFlicks.Domain.Entities;

[Table("cinemas")]
public class CinemaEntity : IdEntity
{
    [Column("name")]
    [StringLength(1024), Required]
    public string Name { get; set; }
    
    [Column("address"), Required]
    public AddressEntity AddressEntity { get; set; }

    public List<FilmEntity> Films { get; } = [];
    public List<FilmCinema> FilmCinemas { get; } = [];

    public override string ToString() => $"name={Name} address={AddressEntity}";
}