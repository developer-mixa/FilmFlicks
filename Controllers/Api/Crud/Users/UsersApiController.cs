using FilmFlicks.Controllers.Api.Crud.Core;
using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Api.Crud.Users;

[Route("api/users")]
public class UsersApiController(IUserRepository userRepository) : CrudController<User>(userRepository);