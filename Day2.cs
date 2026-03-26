namespace AdventOfCode2020.Data;

public static class Day2
{
    private static string path = @"./Data/Day2Data.txt";
    
    private static List<Line> DataToLine()
    {
        List<Line> lst = [];
        foreach (string line in File.ReadAllLines(path))
        {
            string[] newLine = line.Replace("\n", "")
                .Replace(":", "")
                .Split(new char[] { '-', ' ', ':'});
            
            lst.Add(new Line(
                int.Parse(newLine[0]), 
                int.Parse(newLine[1]), 
                char.Parse(newLine[2]), 
                newLine[3]
                ));
        }

        return lst;
    }
    
    public static int GetDay2_1Result()
    {
        int totalCount = 0;
        foreach (Line l in DataToLine())
        {
            int count = l.Code.Count(c => c == l.Target); 
            if (count >= l.Lower && count <= l.Upper)
            {
                totalCount++;
            }
        }
        
        return totalCount;
    }

    public static int GetDay2_2Result()
    {
        int TotalCount = 0;
        foreach (Line line in DataToLine())
        {
            if (line.Code[line.Lower-1] == line.Target ^        // XOR
                line.Code[line.Upper-1] == line.Target)
            {
                TotalCount++;
            }
        }

        return TotalCount;
    }
    
    struct Line(int l, int u, char t, string c)
    {
        public readonly int Lower = l;
        public readonly int Upper = u;
        public readonly char Target = t;
        public readonly string Code = c;
    }
}
