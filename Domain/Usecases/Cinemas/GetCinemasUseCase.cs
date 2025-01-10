using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;

namespace FilmFlicks.Domain.Usecases.Cinemas;

public class GetCinemasUseCase(ICinemaRepository cinemaRepository)
{
    public async Task<IEnumerable<Cinema>> Execute()
    {
        return await cinemaRepository.Select();
    }
}