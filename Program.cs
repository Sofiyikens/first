public static class Program
{
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
                case 4:
                    Console.WriteLine("\nGood bye!");
                    return;
                default:
                    Console.WriteLine("\nInvalid choice. Please, try again!");
                    break;
            }
        }
    }

    private static void GetFactoryById()
    {
        throw new NotImplementedException();
    }

    private static void GetFactories()
    {
        throw new NotImplementedException();
    }

    private static void CreateFactory()
    {
        throw new NotImplementedException();
    }

    public static void Main()
    {
        Terminal();
    }
}