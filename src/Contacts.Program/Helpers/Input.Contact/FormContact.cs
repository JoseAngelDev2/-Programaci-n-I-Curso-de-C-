using System;
using FieldInt;
using FieldString;
using Contact;
using ListOption;
using interfaces;
using AddContacts;
using Infrastructure;

namespace Helpers.InputContact
{


    public class ContactInput : IFormContact
    {
        Contact.MyContact C = new Contact.MyContact();
        AddMyContact A = new AddMyContact();
        FieldString.CheckString S = new FieldString.CheckString();
        ListOption.ConfirmOption L = new ListOption.ConfirmOption();
    
        public void formContact()
        {


            Console.Clear();
            int age;
            string name, lastname, address, phone, email = string.Empty;
            bool option = false;
            bool isBestFriend = false;

            name = CheckString.VerifyFieldString("name", "Ana");
            lastname = CheckString.VerifyFieldString("lasname", "Grabiel");
            address = CheckString.VerifyFieldString("address", "13 main street SC 91000");
            email = CheckString.VerifyFieldString("email", "ana@dominio.com");
            phone = CheckString.VerifyFieldString("phone", "XXX-XXX-XXXX");
            age = CheckedAge.verifyAge("age");
            isBestFriend = ConfirmOption.MultiOptionList.Contains(CheckString.VerifyFieldString("option Isbesfriend [YES OR NO]", "yes"));
            ConfirmContactShowMessage(name, lastname, address, phone, email, age, isBestFriend);
            option = ConfirmOption.MultiOptionList.Contains(Console.ReadLine()!.ToLower());

            if (option)
            { A.AddContact(name, lastname, address, phone, email, age, isBestFriend); }


            // Show message in the fuction AddContact
            void ConfirmContactShowMessage(string name, string lastname, string address, string phone, string email, int age, bool isBestFriend)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n|| ------- CONFIRM IF THE DATA ENTERED IS CORRECT ------- ||\n");
                Console.ResetColor();

                string isBestFriendStr = InContact.ShowMessageBesfriend(isBestFriend);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"1. Name: {name}\n" + $"2. Lastname: {lastname}\n" + $"3. Address: {address}\n" + $"4. Phone: {phone}\n" + $"5. Email: {email}\n" + $"6. Age: {age}\n" + $"7. IsBestFriend: {isBestFriendStr}\n");
                Console.ResetColor();
                Console.WriteLine("Confirm with: [yes/no]");
            }

        }
    }
}


