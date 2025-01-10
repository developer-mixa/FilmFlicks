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
            db.Tickets.Update(ticket);
            await db.SaveChangesAsync();
        }
    }

    public async Task CancelForUser(long ticketId, long userId)
    {
        var ticket = await Get(ticketId);
        
        if (ticket != null)
        {
            ticket.UserId = null;
            db.Tickets.Update(ticket);
            await db.SaveChangesAsync();
        }
    }
}