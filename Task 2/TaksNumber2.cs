


// this program calculates if it is even or odd

bool runinng = true;

while (runinng)
{
    int option = 0;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("------- This program checks if the number is even or odd -------");
    Console.ResetColor();
    try
    {
        Console.WriteLine("1. Check Number   2. exit ");
        Console.Write("Write a option (Just number):");
        option = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception e)
    {
        Console.WriteLine($"ERROR {e}: choose the option correct (JUST 1 OR 2)");
        Console.WriteLine("For example with the number 1");
        option = 1;
    }

    switch (option)
    {
        case 1:
            { IsEvenOrIsOdd(); }
            break;
        case 2:
            { runinng = false; }
            break;

        default:
            { Console.WriteLine("option out of range"); }
            break;
    }

    void IsEvenOrIsOdd()
    {
        Console.Clear();
        int n;
        try
        {
            Console.Write("Write a Number (Just number):");
            n = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR {e}: the number is valid, use just number for example 3");
            n = 3;
        }
        string result = ConfirmIsEvenOrIsOdd(n);
        Console.WriteLine(result);
        Console.ReadKey();
    }
    
    static string ConfirmIsEvenOrIsOdd(int n)
    {
        string result = n % 2 == 0 ? $"{n} is Even" : $"{n} is Odd";
        return result;
    }
}
