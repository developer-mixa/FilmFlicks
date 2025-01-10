using FilmFlicks.DAL.Repositories.Core;
using FilmFlicks.Domain.Repositories;

namespace FilmFlicks.DAL.Repositories.Ticket;

public class DbTicketRepository(ApplicationDbContext db)
    : CrudRepository<Domain.Entities.TicketEntity, long>(db, (ticket, id) => ticket.Id == id), ITicketRepository
{
    public async Task BookForUser(long ticketId, long userId)
    {
        var ticket = await Get(ticketId);
        
        if (ticket != null)
        {
            ticket.UserId = userId;
            await Update(ticket);
        }
    }

    public async Task CancelForUser(long ticketId, long userId)
    {
        var ticket = await Get(ticketId);
        
        if (ticket != null && ticket.UserId == userId)
        {
            ticket.UserId = null;
            await Update(ticket);
        }
    }
    
    
}