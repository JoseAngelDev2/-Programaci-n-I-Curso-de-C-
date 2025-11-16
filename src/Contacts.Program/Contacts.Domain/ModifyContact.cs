using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AddContacts;
using Contact;
using Contact.Domain.AllContact;
using FieldInt;
using FieldString;
using Infrastructure;
using ListOption;
using validations.FoundIdOrPhone;
namespace Domain.ModifyContact
{
    class ModifyContact
    {
        public static MyContact? GetModifyContact()
        {

            Console.Clear();
            Console.WriteLine("------ WELCOME TO MODIFY CONTACT ------\n");
            Console.WriteLine($"                                          ✍️   List Contact Modify   ✍️                                                                      ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("________________________________________________________________________________");
            AllMyContacts.ShowAllContact();
            Console.WriteLine("________________________________________________________________________________");
            Console.ResetColor();
            Console.WriteLine("\n                   👀 Enter the telephone to select the contact. 👀                   \n");
            Console.Write("\nWrite the Contact number or id you would like to modify: ");
            string optionNumber = Console.ReadLine()!;

            var data = VfoundIdOrPhone.FoundIdOrPhone(optionNumber);

            if (data is null)
            {
                return null;
            }
            else if (data is not null)
            {
                data = VfoundIdOrPhone.FoundIdOrPhone(optionNumber);
            }

            return data;
        }

        public static void ModifyMyContact()
        {
            var C = GetModifyContact();
            if (C is null) { Console.WriteLine("The contact no exits"); return; }
            int option = 0;
            bool active = true;
            while (active)
            {
                InContact.ShowContact(C);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n1. Modify Name and Lastname\n2. Modify Address and IsBestfriend\n3. Modify Email and Age\n4. exit\n");
                Console.ResetColor();
                Console.Write("Choose a option (just number): ");
                try
                {
                    option = int.Parse(Console.ReadLine()!);
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Try Again: Please write only number. {e.Message}");
                    Console.ReadKey();
                    Console.ResetColor();
                    return;
                }
                switch (option)
                {
                    case 1:
                        {
                            try
                            {
                                C.Name = CheckString.VerifyFieldString("modify name", "Angel");
                                C.Lasname = CheckString.VerifyFieldString("modify lastname", "Polanco");
                            }
                            catch (Exception err)
                            {
                                Console.WriteLine(err.Message);
                            }

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nChanges:\n\nName: {C.Name}\nLastname: {C.Lasname}\n");
                            Console.ResetColor();
                            Console.ReadKey();


                        }
                        break;
                    case 2:
                        {
                            C.Address = CheckString.VerifyFieldString("modify address", "14 main street SC 19000");

                            bool optionBool = ConfirmOption.MultiOptionList.Contains(CheckString.VerifyFieldString("new option of contact Isbesfriend: ", "yes").ToLower());
                            string ModifyisBesfriendStr = InContact.ShowMessageBesfriend(optionBool);

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nChanges:\n\nAddress: {C.Address}\nIs BestFrIend: {ModifyisBesfriendStr}\n");

                            if (C.IsbesFriend != optionBool)
                            {
                                C.IsbesFriend = optionBool;
                            }
                            else
                            {
                                Console.WriteLine("This option already in BestFriend [YES OR NO]:");
                            }

                            Console.ResetColor();
                            Console.ReadKey();
                            ;

                        }
                        break;
                    case 3:
                        {
                            try
                            {
                                C.Email = CheckString.VerifyFieldString("new email", "angel@dominio.com");
                                C.Age = CheckedAge.verifyAge("modify age");
                            }

                            catch (Exception e)
                            {
                                Console.Write(e.Message);
                            }


                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nChanges:\n\nEmail: {C.Email}\nAge: {C.Age}\n");

                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        {
                            active = false;
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Error: Not can modify this contact select the option correct. Choose [1, 2, 3, 4]");
                        }
                        break;

                }
            }
        }
    }
}