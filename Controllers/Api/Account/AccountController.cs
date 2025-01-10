using FilmFlicks.Controllers.Requests;
using FilmFlicks.Domain.Exceptions;
using FilmFlicks.Domain.Services;
using FilmFlicks.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Api.Account;

[Route("api/accounts")]
public class AccountController(UsersService usersService) : Controller
{
    [HttpPost("register")]
    public async Task<IResult> Register([FromBody] UserRequest request)
    {
        await usersService.Register(request.Username, request.Password);
        
        return Results.Ok();
    }
    
    [HttpPost("login")]
    public async Task<IResult> Login([FromBody] UserRequest request)
    {
        try
        {
            var token = await usersService.Login(request.Username, request.Password);
            HttpContext.Response.Cookies.Append(Envs.GetAuthCookieKey(), token);
            return Results.Ok(token);
        }
        catch (NotFoundException)
        {
            return Results.NotFound();
        }
        catch (WrongPasswordException)
        {
            return Results.BadRequest("Input password is wrong!");
        }

    }
    
}