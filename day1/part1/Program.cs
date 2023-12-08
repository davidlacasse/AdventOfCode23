using System.Diagnostics.CodeAnalysis;

string[] lines = await File.ReadAllLinesAsync("data");
int sum = 0;
foreach (string line in lines)
{
    int? firstDigit = null;
    int? lastDigit = null;
    for (int i = 0; i < line.Length; ++i)
    {
        var currentChar = line[i];
        if (Char.IsDigit(currentChar))
        {

            int value = int.Parse(currentChar.ToString());
            if (firstDigit is null)
            {
                firstDigit = value;
            }

            lastDigit = value;
        }
    }
    if (firstDigit.HasValue && lastDigit.HasValue)
    {
        sum += (firstDigit.Value * 10) + lastDigit.Value;
    }
}
Console.WriteLine(sum);