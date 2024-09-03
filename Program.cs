using LeetCode;
using System;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProblemsSolution problemsSolution = new ProblemsSolution();
            int[] arr=new int[] {1,2,3,5};
            int sum = problemsSolution.SumRange(new int[] { -2, 0, 3, -5, 2, -1 }, 0, 5);
            Console.WriteLine(sum);
        }
    }
}
