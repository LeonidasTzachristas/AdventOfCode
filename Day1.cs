namespace AdventOfCode2020.Data;

public static class Day1
{
    private static string path = @"./Data/Day1Data.txt";
    static List<int> numbers = File.ReadAllLines(path)
        .Select(int.Parse)
        .ToList();


    public static int GetDay1_1Result()
    {
        int result;
        for (int i = 0; i < numbers.Count-1; i++)
        {
            for (int k = 0; k < numbers.Count; k++)
            {
                if (numbers[i] + numbers[k] == 2020)
                {
                    // Console.WriteLine(
                    //     $"{numbers[i]} + {numbers[k]} = " +
                    //     $"{numbers[i] + numbers[k]}");
                    return numbers[i] * numbers[k];
                }
            }
        }

        Console.WriteLine("Nothing found");
        return 0;
    }

    public static int GetDay1_2Result()
    {
        for (int i = 0; i < numbers.Count-2; i++)
        {
            for (int j = 0; j < numbers.Count-1; j++)
            {
                for (int k = 0; k < numbers.Count; k++)
                {
                    if (numbers[i] + numbers[j] + numbers[k] == 2020)
                    {
                        // Console.WriteLine(
                        //     $"{numbers[i]} + {numbers[j]} + {numbers[k]} = " +
                        //     $"{numbers[i] + numbers[j] + numbers[k]}");
                        return numbers[i] * numbers[j] * numbers[k];
                    }
                }
            }
        }
        
        Console.WriteLine("Nothing found");
        return 0;
    }
}
