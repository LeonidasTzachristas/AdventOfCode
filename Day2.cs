namespace AdventOfCode2020.Data;

public static class Day2
{
    private static string path = @"/home/tzack/RiderProjects/AdventOfCode/AdventOfCode2020/Data/Day2Data.txt";
    
    
    public static int GetDay2_1Result()
    {
        List<Line> lst = [];
        int totalCount = 0;
        string[] lines = File.ReadAllLines(path);
        foreach (string line in lines)
        {
            string[] newLine = line.Replace("\n", "").Replace(":", "").Split(new char[] { '-', ' ', ':'});
            lst.Add(new Line
            {
                lower = int.Parse(newLine[0]),
                upper = int.Parse(newLine[1]),
                target = char.Parse(newLine[2]),
                code = newLine[3]
            });
        }
        
        foreach (Line l in lst)
        {
            int count = l.code.Count(c => c == l.target); 
            if (count >= l.lower && count <= l.upper)
            {
                totalCount += 1;
            }
        }
        
        return totalCount;
    }


    struct Line(int l, int u, char t, string c)
    {
        public int lower = l;
        public int upper = u;
        public char target = t;
        public string code = c;
    }
}