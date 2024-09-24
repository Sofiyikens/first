using System;
using System.Collections.Generic;
using System.Linq;

public static class Program
{
    public class Factory
    {
        public int Id { get; set; }
        public double PlanElectricity { get; set; }
        public double InFactElectricity { get; set; }

        public Factory(int id, double planElectricity, double inFactElectricity)
        {
            Id = id;
            PlanElectricity = planElectricity;
            InFactElectricity = inFactElectricity;
        }

        public double GetDeviationFromPlan()
        {
            return InFactElectricity - PlanElectricity;
        }

        public override string ToString()
        {
            return $"Factory ID: {Id}, Planned Electricity: {PlanElectricity}, Actual Electricity: {InFactElectricity}";
        }
    }

    private static List<Factory> _factories = new List<Factory>();

    private static void Terminal()
    {
        while (true)
        {
            Console.WriteLine("\nFactories system: ");
            Console.WriteLine("1. Add factory");
            Console.WriteLine("2. Get factories information");
            Console.WriteLine("3. Get factory information by identifier");
            Console.WriteLine("4. Exit");

            Console.Write("Your choice: ");
            var userChoice = Console.ReadLine();

            if (!int.TryParse(userChoice, out var userChoiceInFormat))
            {
                Console.WriteLine("\nEnter correct data!");
                continue;
            }

            switch (userChoiceInFormat)
            {
                case 1:
                    CreateFactory();
                    break;
                case 2:
                    GetFactories();
                    break;
                case 3:
                    GetFactoryById();
                    break;
                case 5:
                    Console.WriteLine("\nGood bye!");
                    return;
                case 6:
                    Console.WriteLine("\nBonus. My congratulations! :)");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please, try again!");
                    break;
            }
        }
    }

    private static void CreateFactory()
    {
        Console.Write("\n1. Enter electricity capability use per plan: ");
        var planElectricity = Convert.ToDouble(Console.ReadLine());

        Console.Write("2. Enter electricity capability use in fact: ");
        var inFactElectricity = Convert.ToDouble(Console.ReadLine());

        var newFactory = new Factory(_factories.Count + 1, planElectricity, inFactElectricity);

        _factories.Add(newFactory);

        Console.WriteLine("\nFactory has been successfully added!");
    }

    private static void GetFactoryInfo(Factory factory)
    {
        var deviation = factory.GetDeviationFromPlan();
        Console.WriteLine($"\n\t-ID: {factory.Id}\n\t\t-Electricity per plan: {factory.PlanElectricity}" +
                          $"\n\t\t-Electricity in fact: {factory.InFactElectricity}" +
                          $"\n\t\t-Deviation: {Math.Round(deviation, 2)} kWh");
    }

    private static void GetFactories()
    {
        if (_factories.Count == 0)
        {
            Console.WriteLine("\nNo factories available.");
            return;
        }

        Console.WriteLine("\nList of all factories:");
        foreach (var factory in _factories)
        {
            GetFactoryInfo(factory);
        }
    }

    private static void GetFactoryById()
    {
        Console.Write("\nEnter factory identifier: ");
        var factoryIdentifier = Convert.ToInt32(Console.ReadLine());

        var factory = _factories.FirstOrDefault(f => f.Id == factoryIdentifier);

        if (factory is null)
        {
            Console.WriteLine("\nFactory not found! Please, try again!");
            return;
        }

        GetFactoryInfo(factory);
    }
    private static void DeleteFactory()
    {
        Console.Write("\nEnter factory identifier: ");
        var factoryIdentifier = Convert.ToInt32(Console.ReadLine());

        var factory = _factories.FirstOrDefault(f => f.Id == factoryIdentifier);

        if (factory is null)
        {
            Console.WriteLine("\nFactory not found! Please, try again!");
            return;
        }

        _factories.Remove(factory);

        Console.WriteLine("\nFactory has been successfully deleted from the factories list!");
    }


    public static void Main()
    {
        Terminal();
    }
}
