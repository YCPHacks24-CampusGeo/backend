using GameApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GameApi.Controllers;

[Controller]
public abstract class AbstractGameController : ControllerBase
{
    [NonAction]
    public string? GetGameKeyCookie(string gameId)
    {
        if (CookieUtils.TryGetCookie(Request, CookieUtils.GameKey, out string? result)) {
            return result;
        } else
        {
            return null;
        }
    }

    [NonAction]
    public string? GetHostKeyCookie(string gameId)
    {
        if (CookieUtils.TryGetCookie(Request, CookieUtils.HostKey, out string? result))
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
        if (CookieUtils.TryGetCookie(Request, CookieUtils.PlayerKey, out string? result))
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
        if (CookieUtils.TryGetCookie(Request, CookieUtils.GameStateId, out string? result))
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
        CookieUtils.SetCookie(Response, CookieUtils.GameStateId, value);
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
        CookieUtils.SetCookie(Response, CookieUtils.GameKey, value);
    }

    [NonAction]
    public void SetHostKeyCookie(string gameId, string value)
    {
        CookieUtils.SetCookie(Response, CookieUtils.HostKey, value);
    }

    [NonAction]
    public void SetPlayerKeyCookie(string gameId, string value)
    {
        CookieUtils.SetCookie(Response, CookieUtils.PlayerKey, value);
    }
}
