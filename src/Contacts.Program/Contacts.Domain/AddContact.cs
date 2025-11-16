

using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Contact;
using Infrastructure;
using interfaces;



namespace AddContacts
{
    public class GetContact : IAddContact
    {
        public static List<MyContact> listContact = new List<MyContact>();

        int NextID = 1;


        public void AddContact(string name, string lastname, string address, string phone, string email, int age, bool isBestFriend)
        {
            Contact.MyContact C = new MyContact();
            bool FoundPhone = InfaContact.FoundContact(phone);

            if (FoundPhone)
            {
                Console.WriteLine($"The list has Name: {name} | Phone: {phone} registered Contacts. ❎");
                Console.ReadKey();
                return;
            }
            else if (!FoundPhone)
            {
                C.id = NextID++;
                C.Name = name;
                C.Lasname = lastname;
                C.Address = address;
                C.Phone = phone;
                C.Email = email;
                C.Age = age;
                C.IsbesFriend = isBestFriend;
                listContact.Add(C);
            }
        }
    }
}

