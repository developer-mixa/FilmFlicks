using FilmFlicks.DAL.Repositories.Core;
using FilmFlicks.Domain.Entities;

namespace FilmFlicks.Domain.Repositories;

public interface ITicketRepository : IBaseRepository<TicketEntity, long>
{
    Task BookForUser(long ticketId, long userId);
    Task CancelForUser(long ticketId, long userId);

    Task<List<TicketEntity>> SelectTicketsIncludeAll();

}