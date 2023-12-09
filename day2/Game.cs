using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

public class Draw
{

    public int Blue { get; }
    public int Red { get; }
    public int Green { get; }

    public Draw(string data)
    {
        var cubes = data.Split(',').Select(x => x.Trim());
        foreach (var cube in cubes)
        {
            var cubeData = cube.Split(' ');
            var number = int.Parse(cubeData[0]);
            var color = cubeData[1];


            switch (color)
            {
                case "blue":
                    Blue = number;
                    break;

                case "green":
                    Green = number;
                    break;

                case "red":
                    Red = number;
                    break;
            }
        }
    }

    public override string ToString()
    {
        List<string> colors = new();
        if (Blue > 0)
        {
            colors.Add($"{Blue} blue");
        }
        if (Red > 0)
        {
            colors.Add($"{Red} red");
        }
        if (Green > 0)
        {
            colors.Add($"{Green} green");
        }
        return string.Join(", ", colors);
    }

}
public class Game
{
    public int Id { get; }
    public IEnumerable<Draw> Draws { get; }
    public int TotalBlue => Draws.Sum(x => x.Blue);
    public int TotalGreen => Draws.Sum(x => x.Green);
    public int TotalRed => Draws.Sum(x => x.Red);
    public int Total => TotalBlue + TotalGreen + TotalRed;

    public Game(string data)
    {
        var gameData = data.Split(":");
        var gameIdString = gameData[0].Remove(0, 4);

        Id = int.Parse(gameIdString);
        Draws = gameData[1].Split(';').Select(x => new Draw(x.Trim()));
    }

    public bool IsPossible(int blue, int red, int green)
    {
        return Draws.All(x => x.Blue <= blue && x.Red <= red && x.Green <= green);
    }

    public int GetMinimum()
    {
        int minBlue = Draws.Max(x => x.Blue);
        int minGreen = Draws.Max(x => x.Green);
        int minRed = Draws.Max(x => x.Red);
        return minBlue * minGreen * minRed;
    }


    public override string ToString()
    {
        return $"Game {Id}: {string.Join("; ", Draws)} G:{TotalGreen} R:{TotalRed} B:{TotalBlue}";
    }
}