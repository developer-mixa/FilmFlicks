using FilmFlicks.DAL.Repositories.Core;
using FilmFlicks.Domain.Entities;
using Permission = FilmFlicks.Core.Permission;

namespace FilmFlicks.Domain.Repositories;

public interface IUserRepository : IBaseRepository<UserEntity, long>
{
    Task<UserEntity?> GetByUsername(string username);

    Task<HashSet<Permission>> GetUserPermissions(long userId);

    Task CreateWithRole(UserEntity entity);

}