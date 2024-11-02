using GameApi.Utils;

namespace GameApi.Objects;

public class Player
{
    public uint Score { get; set; } = 0;
    public string PlayerKey = Generators.GeneratePlayerKey();
    public string PlayerIcon { get; set; }
    public Guess? CurrentGuess { get; set; } = null;
    public string PlayerName = Generators.GenerateName();

    public Player(string playerIcon)
    {
        PlayerIcon = playerIcon;
    }
}
