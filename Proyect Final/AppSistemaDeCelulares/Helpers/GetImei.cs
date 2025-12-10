using Microsoft.EntityFrameworkCore.Query;

namespace AppSistemaDeCelulares.Helpers;

public class GetImei
{
    
    
    
    public static string? GetRandomImei()
    {
        Random random = new Random();
        
        string imei = string.Empty;
        
        for (int i = 0; i < 15; i++)
        {
            imei += random.Next(0, 10).ToString();
        }
        Console.WriteLine($"Your IMEI: {imei}");
        Console.WriteLine("Press any key to continue...");
        Console.ResetColor();
        Console.ReadKey();       
        return imei;
    }
}