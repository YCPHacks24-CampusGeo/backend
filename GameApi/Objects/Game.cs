using GameApi.Utils;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace GameApi.Objects;

public class Game
{
    public GameOptions GameOptions { get; set; }
    public Location? CurrentLocation { get; set; }
    public ConcurrentQueue<string> AvailableMarkers = GameObjects.CreateMarkerQueue();
    public ConcurrentQueue<Location> AvailableLocations = GameObjects.CreateLocationQueue();
    public uint CurrentRound { get; set; } = 0;
    public string GameKey = Generators.GenerateGameKey();
    public string GameId = Generators.GenerateGameId();
    public string GameStateId = Generators.GenerateGameStateId();
    public string GameState {  get; set; } = GameStates.SETUP;
    public string HostKey = Generators.GenerateHostKey();
    public ConcurrentDictionary<string, Player> Players = new();


    public BetterTimer Timer = new()
    {
        AutoReset = false,
        Enabled = false,
        Interval = Int32.MaxValue
    };
    

    public Game(GameOptions gameOptions)
    {
        GameOptions = gameOptions;
        Timer.Elapsed += Timer_Elapsed;
    }

    private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        Timer.Stop();
        AdvanceRound();
    }

    private void InternalAdvanceGameState(string gameState)
    {
        SillyLog.Log($"Game state change: {gameState} - {GameId}");

        GameState = gameState;
        GameStateId = Generators.GenerateGameStateId();
    }

    private bool StartGuessRound()
    {
        if (CurrentRound >= GameOptions.RoundCount) return false;

        if (!AvailableLocations.TryDequeue(out Location? location)) return false;

        CurrentLocation = location;
        foreach (var player in Players)
        {
            player.Value.CurrentGuess = null;
        }

        Timer.Interval = GameOptions.GuessTime;
        Timer.Start();
        SillyLog.Log($"Guess timer started: {GameId} - {GameOptions.GuessTime}");
        CurrentRound ++;
        InternalAdvanceGameState(GameStates.GUESS);
        return true;
    }

    private bool StartIntermissionRound()
    {
        foreach (var player in Players)
        {
            uint gained = player.Value.CurrentGuess?.Points ?? 0;
            player.Value.Score += gained;
        }

        Timer.Interval = GameOptions.IntermissionTime;
        Timer.Start();
        SillyLog.Log($"Intermission timer started: {GameId} - {GameOptions.IntermissionTime}");
        InternalAdvanceGameState(GameStates.INTERMISSION);
        return true;
    }

    private bool EndGame()
    {
        CurrentLocation = null;

        foreach (var player in Players)
        {
            player.Value.CurrentGuess = null;
        }

        InternalAdvanceGameState(GameStates.COMPLETE);

        return true;
    }

    public bool AdvanceRound()
    {
        SillyLog.Log($"Advance round: {GameId}");

        bool result;
        switch (GameState)
        {
            case GameStates.SETUP:
                result = StartGuessRound();
                if (!result) EndGame();
                return result;
            case GameStates.GUESS:
                StartIntermissionRound();
                return true;
            case GameStates.INTERMISSION:
                result = StartGuessRound();
                if (!result) EndGame();
                return result;
            default:
                return false;
        }
    }

    public bool TryGetPlayer(string playerKey, [NotNullWhen(true)] out Player? player)
    {
        return Players.TryGetValue(playerKey, out player);
    }

    public bool TryJoinGame([NotNullWhen(true)] out Player? player)
    {
        if (GameState != GameStates.COMPLETE)
        {
            if (Players.Count < GameOptions.MaxPlayers)
            {
                if (AvailableMarkers.TryDequeue(out string playerIcon))
                {
                    player = new Player(playerIcon);
                    return Players.TryAdd(player.PlayerKey, player);
                }
            }
        }

        player = null;
        return false;
    }
}
