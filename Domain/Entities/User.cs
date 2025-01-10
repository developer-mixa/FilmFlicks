using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FilmFlicks.Domain.Entities.Core;

namespace FilmFlicks.Domain.Entities;

[Table("users")]
public class User : IdEntity
{
    [Column("username"), Required]
    [MaxLength(50)]
    public string Username { get; set; }
    
    [Column("password"), Required]
    public string PasswordHash { get; set; }
    
    /*[Column("role"), Required]
    public string Role { get; set; }*/
    
}