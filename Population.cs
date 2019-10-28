using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neironki4
{
    class Population
    {
        List<double> FitFunctions;
        public List<Individual> PopulationList { get; set; }
        Population()
        {
            PopulationList = new List<Individual>();
        }

        public double GetFitFunction(Individual individual)
        {
            // Получить фит функцию конкретрной особи
            return 1;
        }

        public List<double> GetFitFunctionAll(List<Individual> PopulationList)
        {
            FitFunctions =  new List<double>();
            // Получить фит функцию популяции

            return FitFunctions;
        }

        public void RouletteСoupling()
        {
            // Скопировал код, реализующий рулетку (не тестил)
            if (FitFunctions != null)
            {
                double sum = 0;
                List<double> probabilities = new List<double>();
                foreach (double elem in FitFunctions)
                {
                    sum += elem;
                }
                foreach(double elem in FitFunctions)
                {
                    probabilities.Add(elem/sum);
                }


            }
        }
    }
}
