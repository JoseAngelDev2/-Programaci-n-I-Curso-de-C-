using Contact;
using Infrastructure;
using AddContacts;
using Contact.Domain.AllContact;
using Domain.SearchContact;
using System.Data.Common;
using validations.FoundIdOrPhone;
namespace Domain.SearchContact
{
    class SearchContact
    {
        public static void SearchMyContact()
        {
            MyContact contact;
            ShowMessageModify();
            string optionNumber = Console.ReadLine()!;
            contact = VfoundIdOrPhone.FoundIdOrPhone(optionNumber);
            InContact.ShowContact(contact);
        }

    

        static void ShowMessageModify()
        {
            Console.Clear();
            Console.WriteLine("------ WELCOME TO Search CONTACT ------\n");
            Console.WriteLine($"                                          ✍️   List Contact   ✍️                                                                      ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("________________________________________________________________________________");
            AllMyContacts.ShowAllContact();
            Console.WriteLine("________________________________________________________________________________");
            Console.ResetColor();
            Console.WriteLine("\n                   👀 Enter the telephone or id to select the contact. 👀                   \n");
            Console.Write("\nWrite the Contact number or id that want you search: ");
        }
    }
}

