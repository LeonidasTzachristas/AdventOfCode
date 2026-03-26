namespace AdventOfCode2020.Data;

public class Day4
{
    private static string path = @"/home/tzack/RiderProjects/AdventOfCode/AdventOfCode2020/Data/Day4Data.txt";
    private static IEnumerable<string> fields = ["byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"];
    
    public static int GetDay4_1Result()
    {
        var passport = File.ReadAllText(path).Split("\n\n");
        int invalids = 0;
        // With full LINQ
        // int invalids = passport.Count(pass => fields.Any(field => !pass.Contains(field)));
        
        foreach (var pass in passport)
        {
            if (fields.Any(field => !pass.Contains(field)))
            {
                invalids++;
            }
        }

        return passport.Length - invalids;
    }
    
    public static void GetDay4_2Result()
    {
        var passport = File.ReadAllText(path).Split("\n\n");
        
        foreach (var pass in passport)
        {
            if (fields.Any(field => !pass.Contains(field))) continue;

            var pss = pass.Split(':').Split("\n");
            
            Console.WriteLine(pss);
            Console.WriteLine();
        }

    }

    class Passport
    {
        
    }
}