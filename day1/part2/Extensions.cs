public static class Extensions
{
    static Dictionary<string, int> numbers = new(){
        {"one", 1},
        {"two", 2},
        {"three", 3},
        {"four", 4},
        {"five", 5},
        {"six", 6},
        {"seven", 7},
        {"eight", 8},
        {"nine", 9},
    };
    public static int ExtractNumbers(this string s)
    {
        Dictionary<int, int> indexes = new Dictionary<int, int>();
        foreach (var number in numbers)
        {
            indexes.TryAdd(s.IndexOf(number.Key), number.Value);
            indexes.TryAdd(s.IndexOf(number.Value.ToString()), number.Value);
            indexes.TryAdd(s.LastIndexOf(number.Key), number.Value);
            indexes.TryAdd(s.LastIndexOf(number.Value.ToString()), number.Value);
        }
        IEnumerable<int> extractedNumbers = indexes.Where(x => x.Key > -1).OrderBy(x => x.Key).Select(x => x.Value);
        return (extractedNumbers.First() * 10) + extractedNumbers.Last();
    }
}