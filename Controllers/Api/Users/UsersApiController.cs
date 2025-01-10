using FilmFlicks.Controllers.Api.Core;
using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Api.Users;

[Route("api/users")]
public class UsersApiController(IUserRepository userRepository) : CrudController<User>(userRepository);