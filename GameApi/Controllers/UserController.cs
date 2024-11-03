using GameApi.Objects;
using GameApi.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace GameApi.Controllers;
[Route("[controller]/[action]")]
[ApiController]
public class UserController : AbstractGameController
{
    [HttpPost]
    public IActionResult MakeGuess([FromBody] GeoLocation location)
    {
        string? gameId = GetGameIdCookie();
        if (gameId == null) return NotFound("Game id cookie not found");

        string? gameKey = GetGameKeyCookie(gameId);
        if (gameKey == null) return NotFound("Game key cookie not found");

        string? gameStateId = GetGameStateIdCookie(gameId);
        if (gameStateId == null) return NotFound("Game state id cookie not found");

        string? playerKey = GetPlayerKeyCookie(gameId);
        if (playerKey == null) return NotFound("Player key cookie not found");

        if (!ServerState.GetGame(gameId, out Game? game)) return NotFound("Game not found");

        if (game.GameKey != gameKey) return Unauthorized("Game key incorrect");

        if (!game.TryGetPlayer(playerKey, out Player? player)) return NotFound("Player not found");

        if (game.GameState != GameStates.GUESS) return Conflict("Game is not in guess");
        if (gameStateId != game.GameStateId) return Conflict("Incorrect game state id");

        SillyLog.Log($"Guess made for {gameId} - player: {player.PlayerName}");

        player.CurrentGuess = new Guess(location, game.CurrentLocation?.GeoLocation);
        
        return Ok();
    }

    [HttpGet]
    public IActionResult GetGuessImage()
    {
        string? gameId = GetGameIdCookie();
        if (gameId == null) return NotFound("Game id cookie not found");

        string? gameKey = GetGameKeyCookie(gameId);
        if (gameKey == null) return NotFound("Game key cookie not found");

        string? gameStateId = GetGameStateIdCookie(gameId);
        if (gameStateId == null) return NotFound("Game state id cookie not found");

        if (!ServerState.GetGame(gameId, out Game? game)) return NotFound("Game not found");

        if (game.GameKey != gameKey) return Unauthorized("Game key incorrect");

        if (game.GameState != GameStates.GUESS) return Conflict("Game is not in guess");
        if (gameStateId != game.GameStateId) return Conflict("Incorrect game state id");

        SillyLog.Log($"Image request made for {gameId}");

        return Ok(game.CurrentLocation?.ImageKey);
    }

    [HttpPost]
    public IActionResult ExitGame()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public IActionResult GetPlayerIcon()
    {
        string? gameId = GetGameIdCookie();
        if (gameId == null) return NotFound("Game id cookie not found");

        string? gameKey = GetGameKeyCookie(gameId);
        if (gameKey == null) return NotFound("Game key cookie not found");

        string? playerKey = GetPlayerKeyCookie(gameId);
        if (playerKey == null) return NotFound("Player key cookie not found");

        if (!ServerState.GetGame(gameId, out Game? game)) return NotFound("Game not found");

        if (game.GameKey != gameKey) return Unauthorized("Game key incorrect");

        if (!game.TryGetPlayer(playerKey, out Player? player)) return NotFound("Player not found");

        SillyLog.Log($"Get icon made for {gameId} - player: {player.PlayerName}");

        return Ok(new
        {
            Icon = player.PlayerIcon,
            Name = player.PlayerName,
        });
    }

    [HttpGet]
    public IActionResult GetPlayerScore()
    {
        string? gameId = GetGameIdCookie();
        if (gameId == null) return NotFound("Game id cookie not found");

        string? gameKey = GetGameKeyCookie(gameId);
        if (gameKey == null) return NotFound("Game key cookie not found");

        string? playerKey = GetPlayerKeyCookie(gameId);
        if (playerKey == null) return NotFound("Player key cookie not found");

        if (!ServerState.GetGame(gameId, out Game? game)) return NotFound("Game not found");

        if (game.GameKey != gameKey) return Unauthorized("Game key incorrect");

        if (!game.TryGetPlayer(playerKey, out Player? player)) return NotFound("Player not found");

        SillyLog.Log($"Get score made for {gameId} - player: {player.PlayerName}");

        return Ok(player.Score);
    }

    [HttpGet]
    public IActionResult JoinGame(string gameId)
    {
        if (!ServerState.GetGame(gameId, out Game? game)) return NotFound("Game not found");

        string? playerKey = GetPlayerKeyCookie(gameId);
        if (playerKey != null)
        {
            if (game.TryGetPlayer(playerKey, out Player? oldPlayer))
            {
                return Conflict("Already in game");
            }
        }

        if (!game.TryJoinGame(out Player? player)) return Conflict("Cannot join game");

        SetGameIdCookie(gameId);
        SetGameKeyCookie(gameId, game.GameKey);
        SetPlayerKeyCookie(gameId, player.PlayerKey);

        SillyLog.Log($"Player joined {gameId} - player: {player.PlayerName}");

        return Ok();
    }

    [HttpGet]
    public IActionResult GetPlayerResults()
    {
        string? gameId = GetGameIdCookie();
        if (gameId == null) return NotFound("Game id cookie not found");

        string? gameKey = GetGameKeyCookie(gameId);
        if (gameKey == null) return NotFound("Game key cookie not found");

        string? gameStateId = GetGameStateIdCookie(gameId);
        if (gameStateId == null) return NotFound("Game state id cookie not found");

        string? playerKey = GetPlayerKeyCookie(gameId);
        if (playerKey == null) return NotFound("Player key cookie not found");

        if (!ServerState.GetGame(gameId, out Game? game)) return NotFound("Game not found");

        if (game.GameKey != gameKey) return Unauthorized("Game key incorrect");

        if (!game.TryGetPlayer(playerKey, out Player? player)) return NotFound("Player not found");

        if (game.GameState != GameStates.INTERMISSION) return Conflict("Game is not in intermission");
        if (gameStateId != game.GameStateId) return Conflict("Incorrect game state id");

        SillyLog.Log($"Player results requested for {gameId} - player: {player.PlayerName}");

        return Ok(new
        {
            Correct = game.CurrentLocation?.GeoLocation,
            Guess = player.CurrentGuess,
        });
    }
}