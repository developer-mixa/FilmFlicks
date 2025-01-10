using System.ComponentModel.DataAnnotations.Schema;

namespace FilmFlicks.Domain.Entities;

[Table("users_to_roles")]
public class UserRoleEntity
{
    [Column("user_id")]
    public long UserId { get; set; }
    
    [Column("role_id")]
    public int RoleId { get; set; }
}