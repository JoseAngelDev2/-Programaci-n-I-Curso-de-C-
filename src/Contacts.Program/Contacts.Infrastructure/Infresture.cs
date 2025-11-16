using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Contact;
using AddContacts;
using FieldString;
using interfaces;

namespace Infrastructure
{
    public class InfaContact : IFoundContact
    {
        public static bool FoundContact(string phone)
        {
            bool Found = GetContact.listContact.Any(x => x.Phone == phone);
            return Found;
        }
    }
}
