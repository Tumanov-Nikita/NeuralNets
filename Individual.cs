using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neironki4
{
    public class Individual
    {
        Random rnd = new Random();
        public List<bool> Chromosomes { get; set; }

        public Individual(List<bool> chromosome)
        {
            Chromosomes = chromosome;
        }

        public Individual Crossover(Individual SecondIndividual)
        {
            int mid = this.Chromosomes.Count/2;
            List<bool> NewChromosome = new List<bool>();
            for (int i = 0; i < mid; i++)
            {
                NewChromosome.Add(this.Chromosomes[i]);
            }
            for (int i = mid; i < SecondIndividual.Chromosomes.Count; i++)
            {
                NewChromosome.Add(SecondIndividual.Chromosomes[mid + i - 1]);
            }
            Individual ResultInd = new Individual(NewChromosome);
            ResultInd.Mutation(rnd.Next(0, Chromosomes.Count));
            return ResultInd;
        }

        public void Mutation(int index)
        {
            if (rnd.Next(0,101)<=40)
                Chromosomes[index] = !Chromosomes[index];
        }
    }
}
