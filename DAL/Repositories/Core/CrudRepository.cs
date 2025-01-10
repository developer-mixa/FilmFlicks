using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FilmFlicks.DAL.Repositories.Core;

public class CrudRepository<T, TB>(
    ApplicationDbContext db,
    Func<T, TB, bool> getEntityFunction
    ) : IBaseRepository<T, TB>
where T: class
{
    public async Task Create(T entity)
    {
        await db.Set<T>().AddAsync(entity);
        await db.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        db.Set<T>().Update(entity);
        await db.SaveChangesAsync();
    }

    public async Task<T?> Get(TB id)
    {
        var entities = await db.Set<T>().ToListAsync();
        return entities.FirstOrDefault(e => getEntityFunction(e, id));
    }

    public async Task<List<T>> Select()
    {
        return await db.Set<T>().ToListAsync();
    }

    public async Task Delete(T entity)
    {
        db.Set<T>().Remove(entity);
        await db.SaveChangesAsync();
    }
}