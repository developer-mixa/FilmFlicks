namespace FilmFlicks.DAL.Options;

public class AuthorizationOptions
{
    public RolePermissions[] RolePermissions { get; set; } = [];
}

public class RolePermissions
{
    public string Role { get; set; } = string.Empty;

    public string[] Permissions { get; set; } = [];
}