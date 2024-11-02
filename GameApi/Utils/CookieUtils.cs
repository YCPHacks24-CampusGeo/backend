using System.Diagnostics.CodeAnalysis;

namespace GameApi.Utils;

public class CookieUtils
{
    public const string GameKey = "GameKey";
    public const string HostKey = "HostKey";
    public const string PlayerKey = "PlayerKey";
    public const string GameId = "GameId";
    public const string GameStateId = "GameStateId";


    private static readonly CookieOptions CookieOptions = new()
    {
        Domain = ".ycp.campusgeo.com",
        HttpOnly = false,
        IsEssential = true,
        Secure = true,
        Path = "/",
    };

    public static bool TryGetCookie(HttpRequest request, string name, [NotNullWhen(true)] out string? result)
    {
        result = null;

        if (request.Cookies.TryGetValue(name, out string? value))
        {
            if (!string.IsNullOrEmpty(value))
            {
                result = value!;
                return true;
            }
        }

        return false;
    }

    public static void SetCookie(HttpResponse response, string name, string value)
    {
        response.Cookies.Append(name, value, CookieOptions);
    }

    public static void RemoveCookie(HttpResponse response, string name)
    {
        response.Cookies.Delete(name);
    }
}
