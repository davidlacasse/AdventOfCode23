var gameLines = File.ReadLines("data");
IEnumerable<Game> games = gameLines.Select(x => new Game(x));
var results = games.Where(game => game.IsPossible(14, 12, 13));
Console.WriteLine(results.Sum(x => x.Id));
Console.WriteLine(games.Sum(x => x.GetMinimum()));




