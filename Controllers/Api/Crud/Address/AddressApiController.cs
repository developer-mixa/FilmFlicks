using FilmFlicks.Controllers.Api.Crud.Core;
using FilmFlicks.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Api.Crud.Address;

[Route("api/addresses")]
public class AddressApiController(IAddressRepository addressRepository) : CrudController<Domain.Entities.AddressEntity>(addressRepository);