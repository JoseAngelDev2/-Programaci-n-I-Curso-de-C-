using interfaces;
namespace FieldInt

{
    public class CheckedAge : IFieldInt
    {
        public static int verifyAge(string Typeinput)
        {

            Console.Write("write the age of the person (only numbers): ");
            int.TryParse(Console.ReadLine(), out int age); // 10
            while (age <= 12 || age >= 120)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nYour age {age} is invalid. Please Enter a age valid\n");

                Console.ResetColor();
                Console.Write("Try of again (Enter a age valid): ");
                int.TryParse(Console.ReadLine(), out age);
            }

            return age;
        }
    }
}