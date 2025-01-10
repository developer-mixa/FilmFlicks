using FilmFlicks.Domain.Entities;

namespace FilmFlicks.Domain.Auth;

public interface IJwtProvider
{
    public string GenerateToken(User user);
}