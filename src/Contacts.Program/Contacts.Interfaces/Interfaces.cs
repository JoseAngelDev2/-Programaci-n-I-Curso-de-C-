using FieldString;

namespace interfaces
{
    interface IFormContact
    {
        void formContact();
    }
    interface IFieldString
    {

        static string VerifyFieldString() => "Ya lo cree";
    }

    interface IFieldInt
    {
        static string verifyAge() => "Ya lo cree";
    }

    interface IAddContact
    {
        void AddContact(string name, string lastname, string address, string phone, string email, int age, bool isBestFriend);
    }

    interface IFoundContact
    {
        static bool FoundContact() => false;
    }

    interface IFoundID
    {
        public static bool InFoundID(int ContactID) => false;
    }


}

