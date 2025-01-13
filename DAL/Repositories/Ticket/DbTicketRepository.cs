using FilmFlicks.DAL.Repositories.Core;
using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmFlicks.DAL.Repositories.Ticket;

public class DbTicketRepository(ApplicationDbContext db)
    : CrudRepository<TicketEntity, long>(db, (ticket, id) => ticket.Id == id), ITicketRepository
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

    public async Task<List<TicketEntity>> SelectTicketsIncludeAll()
    {
        var tickets = await db.Tickets.Include(ticketEntity => ticketEntity.FilmCinema)
            .ThenInclude(filmCinema => filmCinema.Cinema)
            .Include(ticketEntity => ticketEntity.User).Include(ticketEntity => ticketEntity.FilmCinema)
            .ThenInclude(filmCinema => filmCinema.Film).ToListAsync();
        return tickets;
    }
}