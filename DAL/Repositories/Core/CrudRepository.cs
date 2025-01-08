using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace FilmFlicks.DAL.Repositories.Core;

public class CrudRepository<T, TB>(
    DbContext db,
    Func<T, TB, bool> getEntityFunction
    ) : IBaseRepository<T, TB>
where T: class
{
    public async void Create(T entity)
    {
        await db.Set<T>().AddAsync(entity);
        await db.SaveChangesAsync();
    }

    public async void Update(T entity)
    {
        db.Set<T>().Update(entity);
        await db.SaveChangesAsync();
    }

    public async Task<T?> Get(TB id)
    {
        return await db.Set<T>().FirstOrDefaultAsync(e => getEntityFunction(e, id));
    }

    public async Task<List<T>> Select()
    {
        return await db.Set<T>().ToListAsync();
    }

    public async void Delete(T entity)
    {
        db.Set<T>().Remove(entity);
        await db.SaveChangesAsync();
    }
}