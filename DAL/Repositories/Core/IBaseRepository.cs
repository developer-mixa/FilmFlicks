using FilmFlicks.Domain.Entities;

namespace FilmFlicks.DAL.Repositories.Core;

public interface IBaseRepository<T, B>
{
    void Create(T entity);

    void Update(T entity);

    Task<T?> Get(B id);

    Task<List<T>> Select();

    void Delete(T entity);
}