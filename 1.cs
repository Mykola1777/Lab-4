using System;


public class LivingOrganism
{
    public int Energy { get; set; }
    public int Age { get; set; }
    public int Size { get; set; }
}

public class Animal : LivingOrganism, IReproducible, IPredator
{
    public string Species { get; set; }

    public void Reproduce()
    {
        Console.WriteLine("Animal is reproducing.");
    }

    public void Hunt(LivingOrganism prey)
    {
        Console.WriteLine("Animal is hunting.");
    }
}

public class Plant : LivingOrganism
{
    public string Type { get; set; }
}

public class Microorganism : LivingOrganism
{
    public string Type { get; set; }
}

public class Ecosystem
{
    public List<LivingOrganism> Organisms { get; set; }

    public Ecosystem()
    {
        Organisms = new List<LivingOrganism>();
    }

    public void Interact()
    {
        foreach (var organism in Organisms)
        {
            if (organism is IReproducible)
            {
                ((IReproducible)organism).Reproduce();
            }
            if (organism is IPredator)
            {
                ((IPredator)organism).Hunt(new LivingOrganism());
            }
        }
    }
}

public interface IReproducible
{
    void Reproduce();
}

public interface IPredator
{
    void Hunt(LivingOrganism prey);
}

class Program
{
    static void Main(string[] args)
    {
        Ecosystem ecosystem = new Ecosystem();

        Animal lion = new Animal { Energy = 100, Age = 5, Size = 30, Species = "Lion" };
        Plant tree = new Plant { Energy = 50, Age = 10, Size = 300, Type = "Tree" };
        Microorganism bacteria = new Microorganism { Energy = 10, Age = 1, Size = 2, Type = "Bacteria" };

        ecosystem.Organisms.Add(lion);
        ecosystem.Organisms.Add(tree);
        ecosystem.Organisms.Add(bacteria);

        ecosystem.Interact();
    }
}
