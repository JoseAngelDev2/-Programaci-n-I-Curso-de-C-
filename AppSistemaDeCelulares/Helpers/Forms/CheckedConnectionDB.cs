using AppSistemaDeCelulares.Service;
using Microsoft.Data.SqlClient;
using AppCustomer = AppSistemaDeCelulares.Data.ApplicationDbContext;

namespace AppSistemaDeCelulares.Helpers.Forms;


public class CheckedConnectionDB
{
    public static bool CheckConnectionDb()
    {
        try
        {
            Console.WriteLine("Connecting to SQL Server...");
            Console.WriteLine("Checking connection...");
            AppCustomer context = new AppCustomer();
            CustomerServices service = new CustomerServices(context);
            service.GetAllCustomers();

        }
        catch (SqlException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error couldn't connect to the database.");
            Console.WriteLine("the connection could not be established.");
            Console.ResetColor();
            Console.ReadKey();
            return false;
        }
        
        return true;
    } 
        
}