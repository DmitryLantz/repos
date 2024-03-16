using Microsoft.VisualBasic;
using System;

public class OvenOptimizer
{
    static void Main(string[] args)
    {

        int[] res = GetOvens(29, new int[] { 10, 4 });

        foreach (var item in res)
        {
            Console.Write(item + " ");
        }

    }

    public static int[] GetOvens(int numberOfTrays, int[] ovenCapacities)
    {

        List<Tuple<int, List<int>>> result = new List<Tuple<int, List<int>>>();


        for (int i = 0; i < (numberOfTrays / 10) + 2; i++)
        {
            Console.WriteLine("i: " + i);

            Tuple<int, List<int>> k = RecSeeker(numberOfTrays - 10 * i, new List<int>());

            for (int j = 0; j < i; j++)
            {
                Console.WriteLine("j: " + j);
                k.Item2.Add(10);
            }

            result.Add(new Tuple<int, List<int>>(k.Item1, k.Item2));
        }

        result.OrderBy(x => x.Item1).ThenBy(x => x.Item2.Count);


        return result[0].Item2.ToArray();
    }

    public static Tuple<int, List<int>> RecSeeker(int orderRemained, List<int> ovensUsed) {


        if (orderRemained <= 0) 
        {
            return new Tuple<int, List<int>>(Math.Abs(orderRemained), ovensUsed);
        }

        List<int> new_ovensUsed = new List<int>(ovensUsed);
        new_ovensUsed.Add(4);

        return RecSeeker(orderRemained - 4, new_ovensUsed);

        // return new Tuple<int, List<int>> (1, new List<int>(1));
    }
}