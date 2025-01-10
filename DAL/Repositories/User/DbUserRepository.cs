using FilmFlicks.DAL.Repositories.Core;
using FilmFlicks.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmFlicks.DAL.Repositories.User;

public class DbUserRepository(ApplicationDbContext db)
    : CrudRepository<Domain.Entities.User, long>(db, (user, id) => user.Id == id), IUserRepository
{
    public async Task<Domain.Entities.User?> GetByUsername(string username)
    {
        var users = await db.Users.ToListAsync();
        return users.FirstOrDefault(user => user.Username == username);
    }
}