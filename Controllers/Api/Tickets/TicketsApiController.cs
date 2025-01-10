using FilmFlicks.Controllers.Api.Core;
using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Api.Tickets;

[Route("api/tickets")]
public class TicketsApiController(ITicketRepository ticketRepository) : CrudController<Ticket>(ticketRepository);