using AppCustomer = AppSistemaDeCelulares.Data.ApplicationDbContext;
using System.Net.Mail;
using AppSistemaDeCelulares.Models;
using AppSistemaDeCelulares.Service;
using Customer = AppSistemaDeCelulares.Models.Customer;

namespace AppSistemaDeCelulares.Helpers.Forms;

public class FormCustomers
{
    public static async Task FormCustomer()
    {
        Console.Clear();
        Console.Write("Write your name please: ");
        string name = VerifyFieldString("name");
        Console.Write("Write your address please: ");
        string address = VerifyFieldString("address");
        Console.Write("Write your email please: ");
        string email = VerifyFieldString("email");
        Console.Write("Write your phone please: ");
        string phone = VerifyFieldString("phone");

       await RegisterCustomers.RegisterCustomer(name, address, email, phone);

    }
    
    public static string VerifyFieldString(string Typeinput)
    {
        bool active = true;
        string input = Console.ReadLine()!;

        //input = verifyLargeOfCharater(input, Typeinput, TypeExample);

        while (string.IsNullOrWhiteSpace(input))
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You can't leave this field empty. Please try again");
            Console.ResetColor();

            Console.Write($"Try Write again the {Typeinput}");
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
                Console.WriteLine($"Try again to write the email using format valid");
                Console.ResetColor();
                Console.WriteLine("Try again Write you email: ");
                input = VerifyFieldString(" email");
            }
        }

        return input;
       
     
        }
    }

