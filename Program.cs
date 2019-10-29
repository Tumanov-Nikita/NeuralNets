using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neironki4
{
    class Program
    {
        public static double[,] array = { { 76.16,  47,     31.27 , 75.07 , 69.61 , 13.06 , 31.84 , 90.73 , 85 },
                                { 85.5 ,  24.19 , 59.77 , 62.38 , 84.39 , 86.17 , 40.8 ,  35.74 , 90 },
                                { 30.05 , 52.68 , 62.24 , 46.46 , 22.48 , 29.92 , 22.26 , 76.75 , 341},
                                { 66.41 , 57.14 , 16.39 , 84.61 , 46.87 , 89.89 , 28.81 , 77.31 , 65},
                                { 53.84 , 20.48 , 22.26 , 77.73 , 37.29 , 32.46 , 62.13 , 9.41 ,  363},
                                { 13.93 , 17.03 , 14.66 , 67.06 , 16.36 , 57.57 , 93.67 , 51.61 , 45},
                                { 72.91 , 54.19 , 43.15 , 80.41 , 78.09 , 52.15 , 84.74 , 79.47 , 280},
                                { 68.84 , 14.09 , 39.18 , 53.42 , 6.9 ,   20.15 , 44.62 , 80.84 , 267} };
        public static double[] norms = { 400,    250,    150,    300,    310,    275,    455,    350,    999 };

        public static int N = 8;
        public static int m = 9;
        public static int k = 4;
        public static int fitnessFunctionLimit = 1400;
        public static int moneyLimit = 1000;

        static void Main(string[] args)
        {
            int counter = 0;
            Population population = new Population();
            population.PopulationList.Add(new Individual(new List<bool> { true, true, true, true, true, true, true, true}));
            population.PopulationList.Add(new Individual(new List<bool> { false, false, false, false, false, false, false, false}));
            population.PopulationList.Add(new Individual(new List<bool> { true, false, true, false, true, false, true, false}));
            population.PopulationList.Add(new Individual(new List<bool> { false, true, false, true, false, true, false, true}));
            population.PopulationList.Add(new Individual(new List<bool> { true, true, true, true, true, false, false, false}));
            population.PopulationList.Add(new Individual(new List<bool> { true, true, true, true, false, false, false, false}));
            population.PopulationList.Add(new Individual(new List<bool> { true, true, true, true, false, true, false, true}));
            population.PopulationList.Add(new Individual(new List<bool> { false, true, false, false, true, false, false, false }));
            population.PopulationList.Add(new Individual(new List<bool> { false, false, true, false, false, true, false, false }));

            population.GetFitFunctionAll();

            Console.WriteLine(); Console.WriteLine("Начальная популяция");
            foreach (var n in population.PopulationList)
            {
                for (int i = 0; i < n.Chromosome.Count; i++)
                {
                    Console.Write(n.Chromosome[i] + "; ");
                }
                Console.WriteLine();
            }

            //родители для скрещивания
            List<Individual> Parents = new List<Individual>();
            //число особей старой популяции
            int oldPopCount = population.PopulationList.Count();

            //ОСНОВНОЙ АЛГОРИТМ
            while (true)
            {
                Population populationNew = new Population();
                //число особей новой популяции
                int parentCount = 0;
                while (populationNew.PopulationList.Count < oldPopCount)
                {
                    //выбор пары родителей рулеткой
                    Parents = population.RouletteСoupling();

                    parentCount++;
                    Console.WriteLine(); Console.WriteLine("Выбранна пара родителей " + parentCount);
                    foreach (var n in Parents)
                    {
                        for (int i = 0; i < n.Chromosome.Count; i++)
                        {
                            Console.Write(n.Chromosome[i] + "; ");
                        }
                        Console.WriteLine();
                    }

                    Individual child = Parents[0].Crossing(Parents[1]);
                    populationNew.PopulationList.Add(child);
                }
                populationNew.GetFitFunctionAll();
                List<Individual> best = populationNew.Validation();

                Console.WriteLine(); Console.WriteLine("Новая популяция "+ counter++);
                foreach (var n in population.PopulationList)
                {
                    for (int i = 0; i < n.Chromosome.Count; i++)
                    {
                        Console.Write(n.Chromosome[i] + "; ");
                    }
                    Console.WriteLine();
                }

                /*Console.WriteLine(); Console.WriteLine("Лучшие особи");
				foreach (var n in best)
				{
					for (int i = 0; i < n.Chromosomes.Count; i++)
					{
						Console.Write(n.Chromosomes[i] + "; ");
					}
					Console.WriteLine();
				}*/

                //проверка отклонения от нормы
                if (best != null)
                {
                    Console.WriteLine("Лучшие особи:");
                    foreach (Individual individual in best)
                    {
                        for (int i = 0; i < individual.Chromosome.Count; i++)
                        {
                            Console.Write(individual.Chromosome[i] + "; ");
                        }
                        Console.WriteLine();
                    }
                    break;
                }
            }

            Console.ReadLine();
        }
    }
}

