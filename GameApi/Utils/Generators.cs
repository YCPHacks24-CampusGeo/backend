using System.Security.Cryptography;
using System.Text;

namespace GameApi.Utils;

public static class Generators
{
    private static Random insecureRandom = new();
    private static RandomNumberGenerator secureRandom = RandomNumberGenerator.Create();

    private static string GenerateSecureKey(int length)
    {
        byte[] data = new byte[length];

        secureRandom.GetBytes(data);

        var hex = new StringBuilder(length * 2);
        foreach (byte b in data)
        {
            _ = hex.AppendFormat("{0:X2}", b);
        }

        return hex.ToString();
    }

    public static List<string> Modifiers = [
        "Epicly",
        "Golden",
        "Legendary",
        "Master",
        "Mega",
        "r/",
        "Super",
        "Ultra",
        "Smoldering",
        "Godly",
        "Massive",
        "Twitch.tv/",
        "Gargantuan",
        "Giga",
        "Micro",
        "Nano",
        "Yocto",
        "Pico",
        "Floppy",
        "RGB",
        "Ordinary",
        "Vampirical",
        "discord.gg/",
        "ArrayList"
    ];

    private static List<string> Adjectives = [
        "Funky",
        "Slimy",
        "Funny",
        "Flirty",
        "Rough",
        "Blue",
        "Stinky",
        "Scary",
        "Kinky",
        "Sexy",
        "Lanky",
        "Dreamy",
        "Bouncing",
        "Little",
        "Dry",
        "Huge",
        "Sleepy",
        "Techy",
        "Bratty",
        "Wiggly",
        "Gentle",
        "Grimey",
        "Flimsy",
        "Athletic",
        "Walking",
        "Powerful",
        "Hard",
        "Playful",
        "Illegal",
        "Attractive",
        "Colossal",
        "Scary",
        "Witty",
        "Plump",
        "Lazy",
        "Grumpy",
        "Clumsy",
        "Jealous",
        "Step",
        "Scruffy",
        "Purple",
        "Dead",
        "Bubbly",
        "Murderous",
        "Invisible",
        "Sweaty",
        "Speedy",
        "Strange",
        "Derpy",
        "Shiny",
        "Hateful",
        "Loving",
        "Lonely",
        "Dizzy",
        "Officer",
        "Forbidden",
        "Gummy",
        "Vanilla",
        "Spicy",
        "Tasty",
    ];

    private static List<string> Nouns = [
        "Hacker",
        "Dragon",
        "Computer",
        "Bot",
        "Plant",
        "Judge",
        "Penguin",
        "Braden",
        "Potato",
        "Fridge",
        "Ian",
        "Paul",
        "Mark",
        "Hake",
        "RickAstley",
        "Worm",
        "AI",
        "Professor",
        "Balls",
        "Steak",
        "Lizzy",
        "Pikachu",
        "Moscola",
        "Babcock",
        "Nun",
        "Tummy",
        "Dog",
        "Raccoon",
        "Squidward",
        "Bread",
        "Dino",
        "Spaghetti",
        "Taco",
        "Turtle",
        "Bat",
        "GUI",
        "Firewall",
        "Tyrant",
        "IPV4",
        "Dobby",
        "Database",
        "Frog",
        "Wizard",
        "Witch",
        "Kirby",
        "Yogurt",
        "Tool",
        "Sis",
        "Bro"
    ];

    private static T PickInsecureRandomFromList<T>(List<T> list)
    {
        int index = insecureRandom.Next(list.Count);
        return list[index];
    }

    public static string GenerateName()
    {
        return $"{PickInsecureRandomFromList(Modifiers)}{PickInsecureRandomFromList(Adjectives)}{PickInsecureRandomFromList(Nouns)}";
    }

    public static string GenerateGameKey()
    {
        return GenerateSecureKey(12);
    }

    public static string GenerateHostKey()
    {
        return GenerateSecureKey(12);
    }

    public static string GeneratePlayerKey()
    {
        return GenerateSecureKey(12);
    }

    public static string GenerateGameId()
    {
        int value = insecureRandom.Next(1_000_000);
        return value.ToString();
    }

    public static string GenerateGameStateId()
    {
        int value = insecureRandom.Next(1_000_000);
        return value.ToString();
    }
}
