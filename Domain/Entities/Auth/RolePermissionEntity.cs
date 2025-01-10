using System.ComponentModel.DataAnnotations.Schema;

namespace FilmFlicks.Domain.Entities;

[Table("role_to_permissions")]
public class RolePermissionEntity
{
    [Column("role_id")]
    public int RoleId { get; set; }
    
    [Column("permission_id")]
    public int PermissionId { get; set; }
}