using System.Security.Cryptography.X509Certificates;
using AddContacts;
namespace Domain.ModifyContact
{
    class ModifyContact
    {
        void GetModifyContact()
        {
            Console.Clear();
            Console.WriteLine("------ WELCOME TO MODIFY CONTACT ------\n");
            Console.WriteLine($"                                          ✍️   List Contact Modify   ✍️                                                                      ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("________________________________________________________________________________");
            // See Contacts;
            Console.WriteLine("________________________________________________________________________________");
            Console.ResetColor();
            Console.WriteLine("\n                   👀 Enter the telephone to select the contact. 👀                   \n");
            Console.Write("\nWrite the Contact number or id you would like to modify: ");
            string optionNumber = Console.ReadLine()!;
            bool FoundPhone = GetContact.listContact.Any(x => x.Phone != optionNumber);
            if (FoundPhone)
            {
                Console.WriteLine($"The list not registered Contacts ❎");
            }
            else if (!FoundPhone)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("that you want to modify of this contact");
                Console.ResetColor();
                ConfirmModifyContact(optionNumber, 0);
            }
            else if (int.TryParse(optionNumber, out int id))
            {
                bool FoundID = false;
                if (FoundID)
                {
                    ConfirmModifyContact(string.Empty, id);
                }
            }
        }



        void ConfirmModifyContact(string optionNumber, int id)
        {
            ShowContactFound(optionNumber, id);
            int IDNumber = SearchIdOrPhoneNumber(optionNumber, id, telephonesInverted);
            bool active = telephones.ContainsKey(IDNumber);
            int option = 0;
            while (active)
            {

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
                                names[IDNumber] = VerifyFieldString("modify name", "Angel");
                                lastnames[IDNumber] = VerifyFieldString("modify lastname", "Polanco");
                            }
                            catch (Exception err)
                            {
                                Console.WriteLine(err.Message);
                            }

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nChanges:\n\nName: {names[IDNumber]}\nLastname: {lastnames[IDNumber]}\n");
                            Console.ResetColor();
                            Console.ReadKey();
                            ShowContactFound(optionNumber, id);

                        }
                        break;
                    case 2:
                        {
                            addresses[IDNumber] = VerifyFieldString("modify address", "14 main street SC 19000");

                            bool optionBool = MultiOptionList.Contains(VerifyFieldString("new option of contact Isbesfriend: ", "yes").ToLower());
                            string ModifyisBesfriendStr = ShowMessageBesfriend(optionBool);

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nChanges:\n\nAddress: {addresses[IDNumber]}\nIs BestFrIend: {ModifyisBesfriendStr}\n");

                            if (bestFriends[IDNumber] != optionBool)
                            {
                                bestFriends[IDNumber] = optionBool;
                            }
                            else
                            {
                                Console.WriteLine("This option already in BestFriend [YES OR NO]:");
                            }

                            Console.ResetColor();
                            Console.ReadKey();
                            ShowContactFound(optionNumber, id);

                        }
                        break;
                    case 3:
                        {
                            try
                            {
                                emails[IDNumber] = VerifyFieldString("new email", "angel@dominio.com");
                                ages[IDNumber] = verifyAge("modify age");
                            }

                            catch (Exception e)
                            {
                                Console.Write(e.Message);
                            }


                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nChanges:\n\nEmail: {emails[IDNumber]}\nAge: {ages[IDNumber]}\n");

                            Console.ResetColor();
                            Console.ReadKey();
                            ShowContactFound(optionNumber, id);
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