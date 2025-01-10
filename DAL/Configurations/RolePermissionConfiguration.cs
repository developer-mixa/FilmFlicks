using FilmFlicks.DAL.Options;
using FilmFlicks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmFlicks.DAL.Configurations;

public class RolePermissionConfiguration(AuthorizationOptions authorization) : IEntityTypeConfiguration<RolePermissionEntity>
{
    public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
    {
        builder.HasKey(r => new { r.RoleId, r.PermissionId });

        builder.HasData(ParseRolePermissions());
    }

    private RolePermissionEntity[] ParseRolePermissions()
    {
        return authorization.RolePermissions
            .SelectMany(rp => rp.Permissions
                .Select(p => new RolePermissionEntity()
                {
                    RoleId = (int)Enum.Parse<Core.Role>(rp.Role),
                    PermissionId = (int)Enum.Parse<Core.Permission>(p)
                })
            ).ToArray();
    }
}