using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FilmFlicks.Domain.Entities.Core;

namespace FilmFlicks.Domain.Entities;

[Table("users")]
public class UserEntity : IdEntity
{
    [Column("username"), Required]
    [MaxLength(50)]
    public string Username { get; set; }
    
    [Column("password"), Required]
    public string PasswordHash { get; set; }

    public ICollection<RoleEntity> Roles { get; set; } = [];

}