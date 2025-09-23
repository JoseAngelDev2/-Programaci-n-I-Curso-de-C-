


// this program calculates if it is even or odd

Console.Write("Write a number: ");
int number = int.Parse(Console.ReadLine()!);

if (number % 2 == 0)
{
    Console.WriteLine($"The number {number} is even");
}
else
{
    Console.WriteLine($"The number {number} is odd");   
}