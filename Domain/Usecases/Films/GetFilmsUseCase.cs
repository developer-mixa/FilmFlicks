using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;

namespace FilmFlicks.Domain.UseCases.Films;

public class GetFilmsUseCase(IFilmRepository filmRepository)
{
    public async Task<IEnumerable<FilmEntity>> Execute()
    {
        return await filmRepository.Select();
    }
}