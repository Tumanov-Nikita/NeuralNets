using System;
using System.Collections.Generic;
using System.Linq;


namespace Neironki4
{
    class Program
    {
        // Исходная таблица свойств продуктов
        public static double[,] array = { { 0.4,    0.4,    9.8,    47,     100 },
                                          { 6.3,    5.31,   0.56,   78,     75 },
                                          { 6.5,    3.1,    33,     178,    64 },
                                          { 0,      0,      12,     48,     55 },
                                          { 4,      2.7,    6.8,    75,     88 },
                                          { 16,     40,     0,      420,    110 },
                                          { 8.5,    3.3,    48.3,   259,    80 } };
        
        // Нормы свойств
        public static double[] norms = {34, 25, 60, 600};

        // Количество продуктов
        public static int N = 7;
        // Количество свойств у продукта (кроме цены)
        public static int m = 4;
        // Количество необходимых продуктов для рациона
        public static int k = 4;
        // Лимит отклонения
        public static int fitnessFunctionLimit = 17;
        // Денежный лимит
        public static int moneyLimit = 350;

        static void Main(string[] args)
        {
            int counter = 0;
            Population population = new Population();
            population.PopulationList.Add(new Individual(new List<bool> { true, true, true, true, true, true, true}));
            population.PopulationList.Add(new Individual(new List<bool> { false, false, false, false, false, false, false}));
            population.PopulationList.Add(new Individual(new List<bool> { true, false, true, false, true, false, true}));
            population.PopulationList.Add(new Individual(new List<bool> { false, true, false, true, false, true, false}));
            population.PopulationList.Add(new Individual(new List<bool> { true, true, true, true, true, false, false}));
            population.PopulationList.Add(new Individual(new List<bool> { true, true, true, true, false, false, false}));
            population.PopulationList.Add(new Individual(new List<bool> { true, true, true, true, false, true, false}));
            population.PopulationList.Add(new Individual(new List<bool> { false, true, false, false, true, false, false }));
            population.PopulationList.Add(new Individual(new List<bool> { false, false, true, false, false, true, false }));

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

