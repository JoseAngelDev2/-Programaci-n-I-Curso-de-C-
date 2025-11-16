using Helpers.InputContact;
using Contact.Domain.AllContact;
using Domain.ModifyContact;
using Domain.SearchContact;
using Contact.Domain;
bool runing = true;

ContactInput Input = new ContactInput();
Contact.MyContact C = new Contact.MyContact();

while (runing)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\n1. To add the Contact     2. To See all Contacts    3. To Search a Contact     4. To Modify a Contact   5. To Remove a Contact    6. To Exit\n");
    Console.Write("Write the option that you want select (just number): ");
    Console.ResetColor();
    int typeOption = 0;
    try
    {
        typeOption = Convert.ToInt32(Console.ReadLine());
    }

    catch (Exception ex)
    {
        Console.WriteLine($"ERROR {ex.Message}: 👉 WRITE A NUMBER ONLY (1,2,3,4,5,6)");
        Console.ReadKey();
    }

    switch (typeOption)
    {
        case 1:
            { Input.formContact(); }
            break;
        case 2:
            { AllMyContacts.ShowAllContact(); }

            break;
        case 3:
            { SearchContact.SearchMyContact();} // Search
            break;
        case 4:
            { ModifyContact.ModifyMyContact(); }
            break;
        case 5: //delete
            { }
            break;
        case 6:
            { }

            break;
        default:
            Console.WriteLine("Select the option correct in a range (1-6 READ!).");
            break;
    }
}
