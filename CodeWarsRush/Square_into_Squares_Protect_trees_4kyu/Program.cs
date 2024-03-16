using System.Diagnostics;
using System.Text;

public class ProtectTrees // acepted on codewars.com
{
    public static string result = "nothing";
    public static bool flag = false;

    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();

        Console.WriteLine(Decompose(99999));

        sw.Stop();
        Console.WriteLine("Time elapsed: " + sw.ElapsedMilliseconds + "ms");
    }

    public static string Decompose(long n)
    {
        flag = false;
        RecSeeker(n * n, n, new StringBuilder(""));
        return result != "nothing" ? result + "" : null;
    }

    public static void RecSeeker(long remSqr, long prevNum, StringBuilder str)
    {
        //if (flag) return;
        
        // base case
        if (remSqr == 0)
        {
            str.Remove(str.Length - 1, 1);
            result = str.ToString();
            flag = true;
        }

        // body of recursion
        for (long currNum = Math.Min(prevNum - 1, (int) Math.Sqrt(remSqr)); currNum >= 1 && !flag; currNum--) 
        {
            long currRem = remSqr - currNum * currNum;
            // Console.WriteLine($"currNum = {currNum}, currRem = {currRem}");
            // reccurent relation
            if (currRem >= 0) RecSeeker(currRem, currNum, new StringBuilder(currNum + " ").Append(str));
        }
    }
}