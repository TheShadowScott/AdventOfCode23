// JSON serialization and deserialization (for debugging)
using System.Text.Json;

// Alias of bool as `flag`
#pragma warning disable CS8981
using flag = bool;
#pragma warning restore CS8981

JsonSerializerOptions options = new() { WriteIndented = true, MaxDepth = 10 };

List<Game> games = [];

// Game Parsing

using StreamReader sr = new("games.txt");
string? line;

while (!sr.EndOfStream)
{
    line = sr.ReadLine();
    if (line is not null)
    {
        string tricks = line.Split(':')[1];
        string[] trickList = tricks.Split(';');
        List<Game.Trick> gameTricks = [];
        foreach (string trick in trickList)
        {
            // Find the color and the number (in file as `2 red`, `1 blue`, &c.)
            string[] parts = trick.Split(',');
            int _red = 0, _blue = 0, _green = 0;
            foreach (string part in parts)
            {
                string[] colorAndNumber = part.Split(' ');
                if (!int.TryParse(colorAndNumber[1], out _))
                {
                    Console.WriteLine("Error: colorAndNumber.Length != 2");
                    return;
                }
                int number = int.Parse(colorAndNumber[1]);
                string color = colorAndNumber[2];
                switch (color)
                {
                    case "red":
                        _red += number;
                        break;
                    case "blue":
                        _blue += number;
                        break;
                    case "green":
                        _green += number;
                        break;
                }
            }
            var _trick = new Game.Trick() { Red = _red, Blue = _blue, Green = _green };
            gameTricks.Add(_trick);
        }
        Game _game = new(gameTricks);
        games.Add(_game);
    }
}

// Part 1
int gameNumSum = 0;
Game.Trick maxDraws = new() { Red = 12, Green = 13, Blue = 14 };
int gameNum = 1;
foreach (Game game in games)
{
    flag isPossible = true;
    foreach (var trick in game.Tricks ?? [])
    {
        if (trick >> maxDraws)
        {
            isPossible = false;
            break;
        }
    }
    if (isPossible)
    {
        gameNumSum += gameNum;
    }
    gameNum++;
}

Debugger.Assert(gameNum, 101);

Console.WriteLine(gameNumSum);

// Part 2

long powSum = 0;

foreach (Game game in games)
{
    if (game.Tricks is List<Game.Trick> tricks)
    {
        var _tricks = tricks.ToArray();
        Game.Trick greatest = Game.Trick.SelectGreatest(_tricks);
        powSum += greatest.Pow();
    }
}

Console.WriteLine(powSum);