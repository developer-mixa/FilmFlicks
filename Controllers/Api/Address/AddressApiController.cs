using FilmFlicks.Controllers.Api.Core;
using FilmFlicks.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Api.Address;

[Route("api/addresses")]
public class AddressApiController(IAddressRepository addressRepository) : CrudController<Domain.Entities.Address>(addressRepository);