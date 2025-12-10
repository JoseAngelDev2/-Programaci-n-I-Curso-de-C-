using AppSistemaDeCelulares.Helpers.Forms;
using AppCustomer = AppSistemaDeCelulares.Data.ApplicationDbContext;

using AppSistemaDeCelulares.Models;
using AppSistemaDeCelulares.Service;

namespace AppSistemaDeCelulares.Helpers;

public class RegisterCustomers
{
    
     public static async Task RegisterCustomer(string name, string email, string phone, string address)
     { 
         Console.WriteLine("Entro a la funcion"); 
         Console.ReadKey();
        var activeDB =  CheckedConnectionDB.CheckConnectionDb();
        if (activeDB == false){return;}
        
        AppCustomer context = new AppCustomer();
        

        CustomerServices customerServices = new CustomerServices(context);
        var customer = new Customer
        {
            Name = name,
            Email = email,
            Phone = phone,
            Address = address
        };
        Console.WriteLine("Registering Customer...");
        await customerServices.AddCustomer(customer);
        Console.WriteLine("Registered Successfully");
        Console.ReadLine();
        
    }
}