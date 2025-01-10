using FilmFlicks.Core;
using FilmFlicks.Domain.Repositories;

namespace FilmFlicks.Domain.Services;

public class PermissionsService(IUserRepository userRepository)
{
    public Task<HashSet<Permission>> GetPermissionsAsync(long userId)
    {
        return userRepository.GetUserPermissions(userId);
    }
}