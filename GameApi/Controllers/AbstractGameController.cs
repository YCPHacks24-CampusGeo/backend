using GameApi.Objects;
using GameApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GameApi.Controllers;

[Controller]
public abstract class AbstractGameController : ControllerBase
{
    [NonAction]
    public string? GetGameKeyCookie(string gameId)
    {
        string cookieName = $"{gameId}-{CookieUtils.GameKey}";
        if (CookieUtils.TryGetCookie(Request, cookieName, out string? result)) {
            return result;
        } else
        {
            return null;
        }
    }

    [NonAction]
    public string? GetHostKeyCookie(string gameId)
    {
        string cookieName = $"{gameId}-{CookieUtils.HostKey}";
        if (CookieUtils.TryGetCookie(Request, cookieName, out string? result))
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    [NonAction]
    public string? GetPlayerKeyCookie(string gameId)
    {
        string cookieName = $"{gameId}-{CookieUtils.PlayerKey}";
        if (CookieUtils.TryGetCookie(Request, cookieName, out string? result))
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    [NonAction]
    public string? GetGameStateIdCookie(string gameId)
    {
        string cookieName = $"{gameId}-{CookieUtils.GameStateId}";
        if (CookieUtils.TryGetCookie(Request, cookieName, out string? result))
        {
            return result;
        } else
        {
            return null;
        }
    }

    [NonAction]
    public void SetGameStateIdCookie(string gameId, string value)
    {
        string cookieName = $"{gameId}-{CookieUtils.GameStateId}";
        CookieUtils.SetCookie(Response, cookieName, value);
    }

    [NonAction]
    public string? GetGameIdCookie()
    {
        if (CookieUtils.TryGetCookie(Request, CookieUtils.GameId, out string? result))
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    [NonAction]
    public void SetGameIdCookie(string gameId)
    {
        CookieUtils.SetCookie(Response, CookieUtils.GameId, gameId);
    }

    [NonAction]
    public void SetGameKeyCookie(string gameId, string value)
    {
        string cookieName = $"{gameId}-{CookieUtils.GameKey}";
        CookieUtils.SetCookie(Response, cookieName, value);
    }

    [NonAction]
    public void SetHostKeyCookie(string gameId, string value)
    {
        string cookieName = $"{gameId}-{CookieUtils.HostKey}";
        CookieUtils.SetCookie(Response, cookieName, value);
    }

    [NonAction]
    public void SetPlayerKeyCookie(string gameId, string value)
    {
        string cookieName = $"{gameId}-{CookieUtils.PlayerKey}";
        CookieUtils.SetCookie(Response, cookieName, value);
    }
}
