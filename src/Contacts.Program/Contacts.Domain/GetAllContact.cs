using AddContacts;
using FieldString;



namespace Contact.Domain.AllContact
{
    class AllContact
    {

        public void GetAllContact()
        {
            foreach (MyContact data in AddContacts.GetContact.listContact)
            {
                string IsBestFriendStr = CheckString.ShowMessageBesfriend(data.IsbesFriend);
                Console.WriteLine($"___________________________________________________________________________________________________________________________________\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{data.id}. Name: {data.Name} | lastname: {data.Lasname} | address: {data.Address} | telephone: {data.Phone} | email: {data.Email} | age: {data.Age} | Is Best Friend: {IsBestFriendStr}\n");
                Console.ResetColor();
            }
            Console.WriteLine($"___________________________________________________________________________________________________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"total contacts: {GetContact.listContact.Count}");
            Console.ResetColor();
        }
    }
}