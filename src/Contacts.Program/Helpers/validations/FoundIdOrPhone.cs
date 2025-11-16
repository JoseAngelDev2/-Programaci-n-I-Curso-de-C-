using Contact;
using AddContacts;
using Infrastructure;
namespace validations.FoundIdOrPhone
{
    class VfoundIdOrPhone
    {
        public static MyContact FoundIdOrPhone(string optionNumber)
        {
            MyContact contact = null!;
            bool FoundPhone = InContact.InFoundNumber(optionNumber);
            
            if (AddMyContact.listContact.Count == 0)
            {
                Console.WriteLine($"The list has {AddMyContact.listContact.Count} registered Contacts ❎");
                return null!;
            }
            else if (FoundPhone)
            {
                contact = InContact.GetMyContactPhone(optionNumber);
                return contact;
            }
            else if (int.TryParse(optionNumber, out int ContactID))
            {
                bool FoundID = InContact.InFoundID(ContactID);
                if (FoundID)
                {
                    contact = InContact.GetMyContactID(ContactID);
                    return contact;
                }
            }

            return contact!;
        }
    }
}