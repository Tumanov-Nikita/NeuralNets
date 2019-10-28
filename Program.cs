using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neironki4
{
    class Program
    {
       // public static int m = 3;

        static void Main(string[] args)
        {
            Individual Chr1 = new Individual(new List<bool> { true, true, true });
            Individual Chr2 = new Individual(new List<bool> { false, false, false });
            Individual ResChr1 = Chr1.Crossover(Chr2);
            Individual ResChr2 = Chr2.Crossover(Chr1);

            for (int i=0; i < ResChr1.Chromosomes.Count; i++)
            {
                Console.Write(i+" ");
                Console.Write(ResChr1.Chromosomes[i]+" ; ");
                Console.WriteLine(ResChr2.Chromosomes[i]);
            }
            Console.ReadKey();
        }
    }
}
