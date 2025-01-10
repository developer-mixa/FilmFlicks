using FilmFlicks.Domain.Entities;

namespace FilmFlicks.DAL.Repositories.Core;

public interface IBaseRepository<T, B>
{
    Task Create(T entity);

    Task Update(T entity);

    Task<T?> Get(B id);

    Task<List<T>> Select();

    Task Delete(T entity);
}