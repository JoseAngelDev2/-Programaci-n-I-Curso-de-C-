using AppSistemaDeCelulares.Helpers.Forms;
using AppSistemaDeCelulares.Models;
using AppSistemaDeCelulares.Service;
using AppPhoneDevice = AppSistemaDeCelulares.Data.ApplicationDbContext;
namespace AppSistemaDeCelulares.Helpers;

public class RegisterPhoneDevices
{
    public static async Task RegisterPhoneDevice(string brand, string model, string status, string imei, string colorPhone, int id)
    {
        var activeDB =  CheckedConnectionDB.CheckConnectionDb();
        if (activeDB == false){return;}
        
        AppPhoneDevice context = new AppPhoneDevice();

        PhoneDeviceServices phoneService = new PhoneDeviceServices(context);
        var device = new PhoneDevice
        {
            Brand = brand,
            Model = model,
            Status = status,
            IMEI = imei,
            Color = colorPhone,
            CustomerId = id
        };
        
        await phoneService.AddPhoneDevide(device);
    }
}