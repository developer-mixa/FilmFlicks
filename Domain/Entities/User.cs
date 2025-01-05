using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmFlicks.Domain.Entities;

[Table("users")]
public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    [Column("username"), Required]
    [MaxLength(50)]
    public string Username { get; set; }
    
    [Column("password"), Required]
    public string Password { get; set; }
    
}