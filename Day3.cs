using System.Globalization;

namespace AdventOfCode2020.Data;

public static class Day3
{
    private static string path = @"/home/tzack/RiderProjects/AdventOfCode/AdventOfCode2020/Data/Day3Data.txt";

    private static char[][] DataToArray()
    {
        return File.ReadAllLines(path)
            .Select(line => line.ToCharArray())
            .ToArray();
    }

    public static int GetDay3_1Result()
    {
        int TotalCount = 0;
        var (x, y) = (0, 0);
        var map = DataToArray();
        int maxY = map.Length;
        int maxX = map[0].Length;

        while (y < maxY)
        {
            if (map[y][x] == '#')
                TotalCount++;

            y++;
            x = (x + 3) % maxX;
        }

        return TotalCount;
    }

    public static int GetDay3_2Result()
    {
        int TotalValue = 1;
        int count = 0;
        var (x, y) = (0, 0);
        var increment = (xInc: new int[] { 1, 3, 5, 7, 1 },
                         yInc: new int[] { 1, 1, 1, 1, 2 });
        
        var map = DataToArray();
        int maxY = map.Length;
        int maxX = map[0].Length;


        for (int i = 0; i < 5; i++)
        {
            x = y = count = 0;
            while (y < maxY)
            {
                if (map[y][x] == '#')
                    count++;

                y += increment.yInc[i];
                x = (x + increment.xInc[i]) % maxX;
            }

            TotalValue *= count;
        }

        return TotalValue;
    }
}