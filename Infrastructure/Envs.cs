namespace FilmFlicks.Infrastructure;

public static class Envs
{
    private const int DefaultExpire = 12;
    
    public static string GetAuthCookieKey()
    {
        return Environment.GetEnvironmentVariable("COOKIE_KEY") ?? "Default-Auth-Cookie";
    }

    public static string GetSecurityKey()
    {
        return Environment.GetEnvironmentVariable("SECURITY_KEY") ?? "defaultsecutirykeywithmanymanymanymanymanymanymanyandsooooon";
    }
    
    public static int GetExpireHours()
    {
        var hours = Environment.GetEnvironmentVariable("EXPIRE_HOURS") ?? $"{DefaultExpire}";

        return int.TryParse(hours, out var result) ? result : DefaultExpire;
    }
    
}