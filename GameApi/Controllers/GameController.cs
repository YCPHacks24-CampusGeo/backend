using GameApi.Objects;
using GameApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GameApi.Controllers;
[Route("[controller]/[action]")]
[ApiController]
public class GameController : AbstractGameController
{
    [HttpGet]
    public IActionResult GetScores()
    {
        string? gameId = GetGameIdCookie();
        if (gameId == null) return NotFound("Game id cookie not found");

        string? gameKey = GetGameKeyCookie(gameId);
        if (gameKey == null) return NotFound("Game key cookie not found");

        if (!ServerState.GetGame(gameId, out Game? game)) return NotFound("Game not found");

        if (game.GameKey != gameKey) return Unauthorized("Game key incorrect");

        List<object> scores = [];
        foreach (var player in game.Players)
        {
            scores.Add(new
            {
                Name = player.Value.PlayerName,
                Icon = player.Value.PlayerIcon,
                Score = player.Value.Score,
            });
        }

        return Ok(scores);
    }

    [HttpGet]
    public IActionResult GetGameState()
    {
        string? gameId = GetGameIdCookie();
        if (gameId == null) return NotFound("Game id cookie not found");

        string? gameKey = GetGameKeyCookie(gameId);
        if (gameKey == null) return NotFound("Game key cookie not found");

        if (!ServerState.GetGame(gameId, out Game? game)) return NotFound("Game not found");

        if (game.GameKey != gameKey) return Unauthorized("Game key incorrect");

        SetGameStateIdCookie(gameId, game.GameStateId);

        return Ok(new
        {
            TimeLeft = (int) game.Timer.TimeLeft,
            GameState = game.GameState,
        });
    }
}
