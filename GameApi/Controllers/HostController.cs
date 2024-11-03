using GameApi.Objects;
using GameApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GameApi.Controllers;
[Route("[controller]/[action]")]
[ApiController]
public class HostController : AbstractGameController
{
    [HttpPost]
    public IActionResult CreateGame([FromBody] GameOptions gameOptions)
    {
        if (gameOptions.RoundCount <= GameObjects.Locations.Count)
        {
            if (gameOptions.MaxPlayers <= GameObjects.Markers.Count)
            {
                Game game = ServerState.CreateGame(gameOptions);
                SetGameKeyCookie(game.GameId, game.GameKey);
                SetHostKeyCookie(game.GameId, game.HostKey);
                SetGameIdCookie(game.GameId);
                return Ok(game.GameId);

            }

            return UnprocessableEntity($"Max player count exceeds maximum of {GameObjects.Markers.Count}");
        }

        return UnprocessableEntity($"Round count exceeds maximum of {GameObjects.Locations.Count}");
    }

    [HttpGet]
    public IActionResult GetGameSettings()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult StartGame()
    {
        string? gameId = GetGameIdCookie();
        if (gameId == null) return NotFound("Game id cookie not found");

        string? hostKey = GetHostKeyCookie(gameId);
        if (hostKey == null) return NotFound("Host key cookie not found");

        string? gameKey = GetGameKeyCookie(gameId);
        if (gameKey == null) return NotFound("Game key cookie not found");

        string? gameStateId = GetGameStateIdCookie(gameId);
        if (gameStateId == null) return NotFound("Game state id cookie not found");

        if (!ServerState.GetGame(gameId, out Game? game)) return NotFound("Game not found");

        if (game.GameState != GameStates.SETUP) return Conflict("Game is not in setup");
        if (gameStateId != game.GameStateId) return Conflict("Incorrect game state id");

        if (game.HostKey != hostKey) return Forbid("Host key incorrect");
        if (game.GameKey != gameKey) return Unauthorized("Game key incorrect");

        game.AdvanceRound();
        return Ok();
    }

    [HttpPost]
    public IActionResult DeleteGame()
    {
        throw new NotImplementedException();
    }
}
