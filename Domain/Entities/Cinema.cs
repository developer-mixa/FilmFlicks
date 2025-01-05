using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmFlicks.Domain.Entities;

[Table("cinemas")]
public class Cinema
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    [Column("name")]
    [StringLength(1024), Required]
    public string Name { get; set; }
    
    [Column("address"), Required]
    public Address Address { get; set; }
    
    public ICollection<Film> Films { get; set; }
    
    public override string ToString() => $"name={Name} address={Address}";
}