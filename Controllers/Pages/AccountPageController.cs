using FilmFlicks.Controllers.Requests;
using FilmFlicks.Domain.Exceptions;
using FilmFlicks.Domain.Services;
using FilmFlicks.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Pages
{
    [Route("account")]
    public class AccountPageController(UsersService usersService) : Controller
    {

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] UserRequest request)
        {
            
            await usersService.Register(request.Username, request.Password);
            
            return RedirectToAction("Index");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] UserRequest request)
        {
            try
            {
                var token = await usersService.Login(request.Username, request.Password);
                HttpContext.Response.Cookies.Append(Envs.GetAuthCookieKey(), token);
                return RedirectToAction("Index");
            }
            catch (NotFoundException)
            {
                ModelState.AddModelError("", "User not found");
                return View("Login");
            }
            catch (WrongPasswordException)
            {
                ModelState.AddModelError("", "Incorrect password");
                return View("Login");
            }
        }

        [Authorize]
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete(Envs.GetAuthCookieKey());
            return RedirectToAction("Index");
        }
    }
}
