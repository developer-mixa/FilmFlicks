using FilmFlicks.Controllers.Api.Crud.Core;
using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Api.Crud.Tickets;

[Route("api/tickets")]
public class TicketsApiController(ITicketRepository ticketRepository) : CrudController<Ticket>(ticketRepository);