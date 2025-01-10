using FilmFlicks.Core;
using FilmFlicks.DAL.Repositories.Core;
using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Permission = FilmFlicks.Core.Permission;

namespace FilmFlicks.DAL.Repositories.User;

public class DbUserRepository(ApplicationDbContext db)
    : CrudRepository<UserEntity, long>(db, (user, id) => user.Id == id), IUserRepository
{
    public async Task<UserEntity?> GetByUsername(string username)
    {
        var users = await db.Users.ToListAsync();
        return users.FirstOrDefault(user => user.Username == username);
    }

    public async Task<HashSet<Permission>> GetUserPermissions(long userId)
    {
        var roles = await db.Users
            .AsNoTracking()
            .Include(u => u.Roles)
            .ThenInclude(r => r.Permissions)
            .Where(u => u.Id == userId)
            .Select(u => u.Roles)
            .ToArrayAsync();
        
        
        var result = roles
            .SelectMany(r => r)
            .SelectMany(r => r.Permissions)
            .Select(p => (Permission)p.Id)
            .ToHashSet();

        return result;
    }
    
    public async Task CreateWithRole(UserEntity entity)
    {
        var role = await db.Roles
            .SingleOrDefaultAsync(r => r.Id == (int)Role.User) ?? throw new InvalidOperationException();

        entity.Roles = [role];
        
        await db.Set<UserEntity>().AddAsync(entity);
        await db.SaveChangesAsync();
    }

    public async Task<IEnumerable<TicketEntity>> GetUserTickets(long userId)
    {
        return await db.Tickets
            .AsNoTracking()
            .Where(t => t.UserId == userId)
            .Include(ticketEntity => ticketEntity.FilmCinema)
            .ThenInclude(filmCinema => filmCinema.Cinema)
            .Include(ticketEntity => ticketEntity.FilmCinema)
            .ThenInclude(filmCinema => filmCinema.Film)
            .ToListAsync();
    }
}