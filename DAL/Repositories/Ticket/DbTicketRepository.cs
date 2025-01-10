using FilmFlicks.DAL.Repositories.Core;
using FilmFlicks.Domain.Repositories;

namespace FilmFlicks.DAL.Repositories.Ticket;

public class DbTicketRepository(ApplicationDbContext db)
    : CrudRepository<Domain.Entities.TicketEntity, long>(db, (ticket, id) => ticket.Id == id), ITicketRepository;