using AddContacts;
using FieldString;
using Infrastructure;



namespace Contact.Domain.AllContact
{
    class AllMyContacts
    {
        static public void ShowAllContact()
        {
            foreach (MyContact data in AddMyContact.listContact)
            {
                string IsBestFriendStr = InContact.ShowMessageBesfriend(data.IsbesFriend);
                Console.WriteLine($"___________________________________________________________________________________________________________________________________\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{data.id}. Name: {data.Name} | lastname: {data.Lasname} | address: {data.Address} | telephone: {data.Phone} | email: {data.Email} | age: {data.Age} | Is Best Friend: {IsBestFriendStr}\n");
                Console.ResetColor();
            }
            Console.WriteLine($"___________________________________________________________________________________________________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"total contacts: {AddMyContact.listContact.Count}");
            Console.ResetColor();
        }
    }
}