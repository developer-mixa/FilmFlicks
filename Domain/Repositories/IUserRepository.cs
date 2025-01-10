using FilmFlicks.DAL.Repositories.Core;
using FilmFlicks.Domain.Entities;

namespace FilmFlicks.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User, long>
{
    Task<User?> GetByUsername(string username);
}