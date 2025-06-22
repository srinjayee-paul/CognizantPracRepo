using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Ex7
{
    internal class Program
    {
        static double recur(int time, double rate, double amt)
        {
            if (time == 0)
                return amt;
            return recur(time - 1, rate, amt) * (1 + rate);
        }
        static void Main(string[] args)
        {
            Console.Write("Enter initial amount: ");
            double amt = double.Parse(Console.ReadLine());

            Console.Write("Enter annual growth rate (e.g., 0.05 for 5%): ");
            double rate = double.Parse(Console.ReadLine());

            Console.Write("Enter number of years: ");
            int time = int.Parse(Console.ReadLine());

            double value = recur(time, rate, amt);
            Console.WriteLine($"\nPredicted value after {time} years: {value:F2}");
        }
    }
}
