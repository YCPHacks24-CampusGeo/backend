using GameApi.Objects;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace GameApi.Utils;

public static class ServerState
{
    private static ConcurrentDictionary<string, Game> Games = new();

    public static bool GetGame(string gameId, [NotNullWhen(true)] out Game? game)
    {
        return Games.TryGetValue(gameId, out game);
    }

    public static Game CreateGame(GameOptions gameOptions)
    {
        Game game = new Game(gameOptions);
        Games.TryAdd(game.GameId, game);
        return game;
    }
}
