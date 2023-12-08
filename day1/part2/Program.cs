
string[] lines = await File.ReadAllLinesAsync("data");
int sum = 0;

foreach (string line in lines)
{
    sum += line.ExtractNumbers();
}
Console.WriteLine(sum);