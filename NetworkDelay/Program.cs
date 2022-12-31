
using NetworkDelay;

public class Program
{
    public static void Main()
    {
        int[][] graph = new int[][]
        {
               new int[]{ 2, 1, 1 },
               new int[]{ 2, 3, 1 },
               new int[]{ 3, 4, 1 }
        };


        var solution = new Solution();

        Console.WriteLine(solution.NetworkDelayTime(graph, 7, 2));


    }
}


