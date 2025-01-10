using System.ComponentModel.DataAnnotations.Schema;

namespace FilmFlicks.Domain.Entities;

[Table("permissions")]
public class PermissionEntity
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    public ICollection<RoleEntity> Roles { get; set; } = [];

}