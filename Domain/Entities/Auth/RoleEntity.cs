using System.ComponentModel.DataAnnotations.Schema;

namespace FilmFlicks.Domain.Entities;

[Table("roles")]
public class RoleEntity 
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    public ICollection<PermissionEntity> Permissions { get; set; } = [];

    public ICollection<UserEntity> Users { get; set; } = [];

}