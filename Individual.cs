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
        public List<bool> Chromosome { get; set; }

        public Individual(List<bool> chromosome)
        {
            Chromosome = chromosome;
        }

        public Individual Crossing(Individual SecondIndividual)
        {
            int mid = this.Chromosome.Count/2;
            List<bool> NewChromosome = new List<bool>();
            for (int i = 0; i < mid; i++)
            {
                NewChromosome.Add(this.Chromosome[i]);
            }
            for (int i = mid; i < SecondIndividual.Chromosome.Count; i++)
            {
                NewChromosome.Add(SecondIndividual.Chromosome[i]);
            }
            Individual ResultInd = new Individual(NewChromosome);
            ResultInd.Mutation(rnd.Next(0, Chromosome.Count));
            return ResultInd;
        }

        public void Mutation(int index)
        {
            if (rnd.Next(0,101)<=40)
                Chromosome[index] = !Chromosome[index];
        }
    }
}
