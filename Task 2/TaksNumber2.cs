


// this program calculates if it is even or odd

Console.Write("Write a number: ");
int number = int.Parse(Console.ReadLine()!);

string result = (number % 2 == 0) ? $"The number {number} is even" : $"The number {number} is odd";

Console.Write(result);
