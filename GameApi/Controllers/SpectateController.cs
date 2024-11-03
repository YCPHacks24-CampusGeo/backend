using GameApi.Objects;
using GameApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GameApi.Controllers;
[Route("[controller]/[action]")]
[ApiController]
public class SpectateController : AbstractGameController
{
    [HttpGet]
    public IActionResult WatchGame(string gameId)
    {
        if (!ServerState.GetGame(gameId, out Game? game)) return NotFound("Game not found");

        SetGameIdCookie(gameId);
        SetGameKeyCookie(gameId, game.GameKey);

        return Ok();
    }
    

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
    public IActionResult GetGuesses()
    {
        string? gameId = GetGameIdCookie();
        if (gameId == null) return NotFound("Game id cookie not found");

        string? gameKey = GetGameKeyCookie(gameId);
        if (gameKey == null) return NotFound("Game key cookie not found");

        string? gameStateId = GetGameStateIdCookie(gameId);
        if (gameStateId == null) return NotFound("Game state id cookie not found");

        if (!ServerState.GetGame(gameId, out Game? game)) return NotFound("Game not found");

        if (game.GameState != GameStates.INTERMISSION) return Conflict("Game is not in intermission");
        if (gameStateId != game.GameStateId) return Conflict("Incorrect game state id");

        if (game.GameKey != gameKey) return Unauthorized("Game key incorrect");

        Location correct = game.CurrentLocation;
        List<object> guesses = [];
        foreach (var player in game.Players)
        {
            guesses.Add(new
                {
                    Name = player.Value.PlayerName,
                    Icon = player.Value.PlayerIcon,
                    Guess = player.Value.CurrentGuess?.Location
                });
        }

        return Ok(new
        {
            Correct = correct,
            Guesses = guesses
        });
    }
}
