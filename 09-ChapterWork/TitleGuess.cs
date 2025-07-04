namespace Chapter9;

public class TitleGuess
{
    const string Genes = "abcdefghijklmnopqrstuvwxyz#ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
    const string Target = "C# Data Structures and Algorithms";
    Random Random = new();
    
    
    public void Demo()
    {

        var generationNo = 0;
        List<Individual> population = [];
        for (var i = 0; i < 1000; i++)
        {
            var chromosome = GetRandomChromosome();
            population.Add(new(chromosome, GetFitness(chromosome)));
        }

        List<Individual> generation = [];
        while (true)
        {
            population.Sort((a, b) => b.Fitness.CompareTo(a.Fitness));
            if (population[0].Fitness == Target.Length)
            {
                Print();
                break;
            }

            generation.Clear();
            for (var i = 0; i < 200; i++)
            {
                generation.Add(population[i]);
            }

            for (var i = 0; i < 800; i++)
            {
                var p1 = population[Random.Next(400)];
                var p2 = population[Random.Next(400)];
                var offspring = Mate(p1, p2);
                generation.Add(offspring);
            }

            population.Clear();
            population.AddRange(generation);
            Print();
            generationNo++;
        }
        return;
        
        void Print() => Console.WriteLine(
            $"Generation {generationNo:D2}: {population[0].Chromosome} / {population[0].Fitness}");
        
    }


    Individual Mate(Individual p1, Individual p2)
    {
        var child = string.Empty;
        for (var i = 0; i < Target.Length; i++)
        {
            var r = Random.Next(101) / 100.0f;
            if (r < 0.45f) {child += p1.Chromosome[i];}
            else if (r < 0.9f) {child += p2.Chromosome[i];}
            else {child += GetRandomGene();}
        }

        return new Individual(child, GetFitness(child));
    }

    char GetRandomGene() => Genes[Random.Next(Genes.Length)];

    string GetRandomChromosome()
    {
        var chromosome = string.Empty;
        for (var i = 0; i < Target.Length; i++)
        {
            chromosome += GetRandomGene();
        }

        return chromosome;
    }

    int GetFitness(string chromosome)
    {
        var fitness = 0;
        for (var i = 0; i < Target.Length; i++)
        {
            if (chromosome[i] == Target[i]) {fitness++;}
        }

        return fitness;
    }

    

}