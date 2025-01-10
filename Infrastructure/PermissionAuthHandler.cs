using FilmFlicks.Domain.Services;
using Microsoft.AspNetCore.Authorization;

namespace FilmFlicks.Infrastructure;

public class PermissionAuthHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public PermissionAuthHandler(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }
    
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        var userId = context.User.Claims.FirstOrDefault(
            c => c.Type == CustomClaims.UserId
        );

        if (userId is null || !long.TryParse(userId.Value, out var id))
        {
            return;
        }

        using var scope = _serviceScopeFactory.CreateScope();

        var permissionService = scope.ServiceProvider.GetRequiredService<PermissionsService>();

        var permissions = await permissionService.GetPermissionsAsync(id);

        if (permissions.Intersect(requirement.Permissions).Any())
        {
            context.Succeed(requirement);
        }
    }
}