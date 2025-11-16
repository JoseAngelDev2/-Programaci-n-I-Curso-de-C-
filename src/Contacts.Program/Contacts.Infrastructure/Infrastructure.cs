using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Contact;
using AddContacts;
using FieldString;
using interfaces;

namespace Infrastructure
{
    public class InContact : IFoundContact
    {
        public static bool InFoundNumber(string phone)
        {
            bool Found = AddMyContact.listContact.Any(x => x.Phone == phone);
            return Found;
        }

        public static bool InFoundID(int ContactID)
        {
            bool FoundID = AddMyContact.listContact.Any(i => i.id == ContactID);
            return FoundID;
        }

        public static MyContact GetMyContactID(int id)
        {
            MyContact contact = AddMyContact.listContact.Where(c => c.id == id).FirstOrDefault()!;
            return contact;
        }

        public static MyContact GetMyContactPhone(string phone)
        {
            MyContact contact = AddMyContact.listContact.Where(c => c.Phone == phone).FirstOrDefault()!;
            return contact;
        }

        public static MyContact GetContact(MyContact contact)
        {
            return contact;
        }

        public static string ShowMessageBesfriend(bool isBestFriend)
        {
            string isBestFriendStr = isBestFriend ? "YES" : "NO";
            return isBestFriendStr;
        }

        public static void ShowContact(MyContact C)
        {
            if (C == null) { Console.WriteLine("this Contact not exits ❎"); return; }
            string isBestFriendStr = InContact.ShowMessageBesfriend(C.IsbesFriend);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Select ✅ - {C.id}. Name: {C.Name} | lastname {C.Lasname} | address: {C.Address} | telephone: {C.Phone} | email: {C.Email} | age: {C.Age} | Is Best Friend: {isBestFriendStr}\n");
            Console.ResetColor();
        }

    }
}
