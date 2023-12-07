using System.Text;

/* Debugging Packages */
using System.Text.Json;
JsonSerializerOptions options = new() { WriteIndented = true, MaxDepth = 5 };

// Part 1

// Create a file reader
using StreamReader reader = new("data.txt");
List<List<int>> data = [];

// Read the file and display it line by line.
int lineNum = 0;
while (!reader.EndOfStream)
{
    string? line = reader.ReadLine();
    if (line is not null)
    {
        // Replace spelled out numbers with digits
        // However, overlaps are replaced with both digits, e.g., twone => 21

        string replaced = ReplaceSpelledOutNumbers(line);

        data.Add([]);
        char[] chars = replaced.ToCharArray();
        foreach (char c in chars)
        {
            if (char.IsDigit(c))
            {
                data[lineNum].Add(int.Parse(c.ToString()));
            }
        }
    }
    lineNum++;
}

int sum = 0;

foreach (List<int> line in data)
{
    sum += line.Count switch
    {
        0 => 0,
        1 => 11 * line[0],
        >= 2 => 10 * line[0] + line[^1],
        _ => throw new Exception("Invalid line length")
    };
}

Console.WriteLine(sum);

Console.WriteLine(ReplaceSpelledOutNumbers("twone"));


static string ReplaceSpelledOutNumbers(string line)
{
    Dictionary<string, string> numbers = new()
    {
        { "twone", "21"},
        { "eighthree", "83"},
        { "sevenine", "79" },
        { "eightwo", "82" },
        { "fiveight", "58" },
        { "threeight", "38"},
        { "oneight", "18" },
        { "zerone", "01"},
        { "one", "1" },
        { "two", "2" },
        { "three", "3" },
        { "four", "4" },
        { "five", "5" },
        { "six", "6" },
        { "seven", "7" },
        { "eight", "8" },
        { "nine", "9" },
        { "zero", "0" }
    };
    foreach (KeyValuePair<string, string> number in numbers)
    {
        line = line.Replace(number.Key, number.Value);
    }
    return line;
}