using FilmFlicks.Core;
using Microsoft.AspNetCore.Authorization;

namespace FilmFlicks.Infrastructure;

public class PermissionRequirement(Permission[] permissions) : IAuthorizationRequirement
{
    public Permission[] Permissions { get; set; } = permissions;
}