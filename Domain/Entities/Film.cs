using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmFlicks.Domain.Entities;

[Table("films")]
public class Film
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    [Column("name")]
    [MaxLength(1024), Required]
    public string Name { get; set; }
    
    [Column("description"), Required]
    public string Description { get; set; }
    
    [Column("rating"), Required]
    [Range(0f, 10f)]
    public float Rating { get; set; }
    
    public ICollection<Cinema> Cinemas { get; set; }

    public override string ToString() => $"name={Name} rating={Rating}";
}