using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neironki4
{
    public class Population
    {
        Random rnd;
        private List<double> FitFunctions;
        public List<Individual> PopulationList { get; set; }
        public Population()
        {
            PopulationList = new List<Individual>();
            FitFunctions = new List<double>();
            rnd = new Random();
        }

        public void GetFitFunctionAll()
        {
            FitFunctions.Clear();
            List<double> fitFunctionsCalc = new List<double>();
            foreach (Individual individual in PopulationList) {
                double function = 0;
                for (int j = 0; j < Program.N; j++)
                {
                    for (int i = 0; i < Program.N; i++)
                    {
                        if (individual.Chromosome[i])
                        {
                            function += Program.array[i, j];
                        }
                    }
                }
                fitFunctionsCalc.Add(function);
            }
            this.FitFunctions = fitFunctionsCalc;
        }

        public List<Individual> Validation()
        {
            List<Individual> resultList = new List<Individual>();
            foreach (Individual individual in PopulationList)
            {
                int genes = individual.Chromosome.Count(c => c == true);
                int index = PopulationList.FindIndex(i => i.Equals(individual));
                double summa = 0;
                for (int i = 0; i < individual.Chromosome.Count - 1; i++)
                {
                    if (individual.Chromosome[i])
                    {
                        summa += Program.array[i,Program.N];
                    }
                }
                if (genes == Program.k && FitFunctions[index] < Program.fitnessFunctionLimit && summa < Program.moneyLimit)
                {
                    resultList.Add(individual);
                }
            }
            if (resultList.Count != 0)
            {
                return resultList;
            }
            else
            {
                return null;
            }
        }

        public List<Individual> RouletteСoupling()
        {
            if (FitFunctions != null)
            {
                Individual parent1 = null;
                Individual parent2 = null;
                double sum = 0;
                List<double> probabilities = new List<double>();

                sum = FitFunctions.Sum();

                foreach (double elem in FitFunctions)
                {
                    probabilities.Add(elem / sum);
                }

                while (parent2 == null)
                {
                    int expectantIndex = rnd.Next(FitFunctions.Count);
                    if (probabilities[expectantIndex] < rnd.Next(100))
                    {
                        if (parent1 == null)
                        {
                            parent1 = PopulationList[expectantIndex];
                        }
                        else
                        {
                            if (parent1 != PopulationList[expectantIndex])
                            {
                                parent2 = PopulationList[expectantIndex];
                            }  
                        }
                    }
                }

                List<Individual> Parents = new List<Individual>();
                Parents.Add(parent1);
                Parents.Add(parent2);
                return Parents;
            }
            else
            {
                return null;
            }
        }
    }
}
