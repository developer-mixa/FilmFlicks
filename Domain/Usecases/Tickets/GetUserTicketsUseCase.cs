using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;

namespace FilmFlicks.Domain.Usecases.Tickets;

public class GetUserTickets(
    IUserRepository userRepository
    )
{
    public async Task<IEnumerable<TicketEntity>> Execute(long userId)
    {
        return await userRepository.GetUserTickets(userId);
    }
}