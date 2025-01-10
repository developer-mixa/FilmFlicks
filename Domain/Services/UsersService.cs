using FilmFlicks.Domain.Auth;
using FilmFlicks.Domain.Entities;
using FilmFlicks.Domain.Exceptions;
using FilmFlicks.Domain.Repositories;

namespace FilmFlicks.Domain.Services;

public class UsersService(
    IPasswordHasher passwordHasher,
    IUserRepository userRepository,
    IJwtProvider jwtProvider
)
{
    public async Task Register(string username, string password)
    {
        var hashedPassword = passwordHasher.Generate(password);
        
        var user = new UserEntity
        {
            Username = username,
            PasswordHash = hashedPassword
        };

        await userRepository.CreateWithRole(user);
    }

    public async Task<string> Login(string username, string password)
    {
        var user = await userRepository.GetByUsername(username) ?? throw new NotFoundException();

        var verify = passwordHasher.Verify(password, user.PasswordHash);

        if (!verify)
        {
            throw new WrongPasswordException();
        }

        var token = jwtProvider.GenerateToken(user);

        return token;
    }
    
}