using System.Net.Mail;
using interfaces;

namespace FieldString
{
    class CheckString : IFieldString
    {

        public static string VerifyFieldString(string Typeinput, string TypeExample)
        {
            bool active = true;
            Console.Write($"Write the {Typeinput} of the person [ej: {TypeExample}]: ");
            string input = Console.ReadLine()!;

            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You can't leave this field empty. Please try again");
                Console.ResetColor();

                Console.Write($"Try Write again the {Typeinput} [ej: {TypeExample}]: ");
                input = Console.ReadLine()!;
            }

            while (Typeinput == "email" && active)
            {
                try
                {
                    var mail = new MailAddress(input);
                    active = false;
                }
                catch (FormatException ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"Try again to write the email using format valid [ej: {TypeExample}]");
                    Console.ResetColor();
                    input = VerifyFieldString(" email. Try to again with format valid", "ana@gmail.com");
                }
            }


            input = verifyLargeOfCharater(input, Typeinput, TypeExample);

            return input;

        }

        public static string verifyLargeOfCharater(string input, string Typeinput, string TypeExample)
        {

            const int allowedNumbers = 11;
            const int allowedCharactersShort = 25;
            const int allowedCharactersLarge = 35;


            if (Typeinput == "lasname" || Typeinput == "name")
            {
                while (input.Length > allowedCharactersShort)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You {Typeinput} is very large. allowed characters {allowedCharactersShort}. Please try again");
                    Console.ResetColor();
                    Console.Write($"Try Write again the {Typeinput} [ej: {TypeExample}]: ");
                    input = Console.ReadLine()!;
                }
            }
            if (Typeinput == "email" || Typeinput == "address")
            {
                while (input.Length > allowedCharactersLarge)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You {Typeinput} is very large. allowed characters {allowedCharactersLarge}. Please try again");
                    Console.ResetColor();
                    Console.Write($"Try Write again the {Typeinput} [ej: {TypeExample}]: ");
                    input = Console.ReadLine()!;
                }
            }
            if (Typeinput == "phone")
            {
                while (input.Length > allowedNumbers)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You {Typeinput} is very large. The limit is {allowedNumbers} Charater. Please try again");
                    Console.ResetColor();
                    Console.Write($"Try Write again the {Typeinput} [ej: {TypeExample}]: ");
                    input = Console.ReadLine()!;
                }
            }

            return input;

        }

    }
}