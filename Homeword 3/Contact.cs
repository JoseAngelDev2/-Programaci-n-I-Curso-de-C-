using System.Security.AccessControl;
List<String> MultiOptionList = ["yes", "ye", "y", "1"];
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<string, int> telephonesInverted = new Dictionary<string, int>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

bool runing = true;


int CountID = 1;
while (runing)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\n1. To add the Contact     2. To See all Contacts    3. To Search a Contact     4. To Modify a Contact   5. To Remove a Contact    6. To Exit\n");
    Console.Write("Write the option that you want select (just number): ");
    Console.ResetColor();
    int typeOption = 0;
    try
    {
        typeOption = Convert.ToInt32(Console.ReadLine());
    }

    catch (Exception ex)
    {
        Console.WriteLine($"ERROR {ex.Message}: 👉 WRITE A NUMBER ONLY (1,2,3,4,5,6)");
        Console.ReadKey();
    }

    switch (typeOption)
    {
        case 1:
            {
                formContact();
            }
            break;
        case 2: //extract this to a method
            {
                Console.WriteLine("                                                ---------- 📕 LIST CONTACT  📕 ---------\n");
                ShowAllContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }

            break;
        case 3: //search
            {
                SearchContact();
            }
            break;
        case 4: //modify
            {
                ModifyContact();
            }
            break;
        case 5: //delete
            {
                ConfirmDeleteContact();
            }
            break;
        case 6:
            {
                Console.Write("You this sure that want exit of Program: ");
                bool option = MultiOptionList.Contains(Console.ReadLine()!.ToLower());
                runing = ConfirmExit(option); ;
            }

            break;
        default:
            Console.WriteLine("Select the option correct in a range (1-6 READ!).");
            break;
    }
}



// -----------------------------------------------------------------------------
void formContact()
{
    Console.Clear();
    int age;
    string name, lastname, address, phone, email = string.Empty;
    bool option = false;
    bool isBestFriend = false;

    name = VerifyEmptyfield("name", "Ana");
    lastname = VerifyEmptyfield("lasname", "Grabiel");
    address = VerifyEmptyfield("address", "13 main street SC 91000");
    email = VerifyEmptyfield("email", "ana@dominio.com");
    phone = VerifyEmptyfield("phone", "XXX-XXX-XXXX");
    age = verifyAge("age");
    isBestFriend = MultiOptionList.Contains(VerifyEmptyfield("option Isbesfriend [YES OR NO]", "yes"));
    string IsBestFriendStr = ShowMessageBesfriend(isBestFriend);
    ConfirmContactShowMessage(name, lastname, address, phone, email, age, isBestFriend);
    option = MultiOptionList.Contains(Console.ReadLine()!.ToLower());

    if (option) { AddContact(name, lastname, address, phone, email, age, isBestFriend); }
}


static string VerifyEmptyfield(string Typeinput, string TypeExample)
{
    Console.Write($"Write the {Typeinput} of the person [ej: {TypeExample}]: ");
    string input = Console.ReadLine()!;
    while (string.IsNullOrWhiteSpace(input))
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You can't leave this field empty. Please try again");
        Console.ResetColor();
        Console.WriteLine($"Try Write again the {Typeinput} [ej: {TypeExample}]: ");
        input = Console.ReadLine()!;
    }

    return input;
}


void AddContact(string name, string lastname, string address, string phone, string email, int age, bool isBestFriend)
{
    if (telephones.ContainsValue(phone))
    {
        Console.Clear();
        int IDNumber = telephonesInverted[phone];
        Console.ForegroundColor = ConsoleColor.Green;
        isBestFriend = bestFriends[IDNumber];
        string isBestFriendStr = ShowMessageBesfriend(isBestFriend);
        Console.WriteLine($"This phone number is already registered:\n");
        Console.WriteLine($"1. Name: {names[IDNumber]}\n" + $"2. Lastname: {lastnames[IDNumber]}\n" + $"3. Address: {addresses[IDNumber]}\n" + $"4. Phone: {telephones[IDNumber]}\n" + $"5. Email: {emails[IDNumber]}\n" + $"6. Age: {ages[IDNumber]}\n" + $"7. IsBestFriend: {isBestFriendStr}\n");
        Console.ReadKey();
        Console.ResetColor();
        return;
    }
    else if (!telephones.ContainsValue(phone))
    {

        int id = CountID++;
        AddNewContact(id, phone, name, lastname, address, email, age, isBestFriend);
        Console.Clear();
        Console.WriteLine($"saved in the contact list telephone ✅");
        Console.ReadKey();
        return;
    }
    else
    {
        Console.Clear();
        Console.WriteLine("ERROR: the contact could not be saved");
    }
}

void AddNewContact(int id, string phone, string name, string lastname, string address, string email, int age, bool isBestFriend)
{
    try
    {
        telephonesInverted.Add(phone, id);
        ids.Add(id);
        telephones.Add(id, phone);
        names.Add(id, name);
        lastnames.Add(id, lastname);
        addresses.Add(id, address);
        emails.Add(id, email);
        ages.Add(id, age);
        bestFriends.Add(id, isBestFriend);
    }
    catch (Exception err)
    {
        Console.WriteLine("the contact could not saved");
        Console.WriteLine(err.Message);
    }
}

// ---------------------------------------------------------------------------


// -----------------------------------------------------
static void ShowAllContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    foreach (int id in ids) // 1, 3
    {
        var isBestFriend = bestFriends[id];

        string isBestFriendStr = ShowMessageBesfriend(isBestFriend);

        Console.WriteLine($"___________________________________________________________________________________________________________________________________\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{id}. Name: {names[id]} | lastname: {lastnames[id]} | address: {addresses[id]} | telephone: {telephones[id]} | email: {emails[id]} | age: {ages[id]} | Is Best Friend: {isBestFriendStr}\n");
        Console.ResetColor();
    }
    Console.WriteLine($"___________________________________________________________________________________________________________________________________\n");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"total contacts: {ids.Count}");
    Console.ResetColor();
}

// -----------------------------------------------------



// -----------------------------------------------------
void SearchContact()
{
    Console.Clear();
    Console.WriteLine("                         ---- Search Contant ---");
    ShowAllContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
    Console.Write("\nWrite the Contacts number you would like to search: ");

    string userSearch = Console.ReadLine()!;


    var foundPhone = telephonesInverted.Where(x => x.Key == userSearch).FirstOrDefault();

    if (telephones.Count == 0) // TODO: Hacer mas tarde en los
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The list has no registered Contacts ❎");
        Console.ResetColor();
        return;
    }

    else if (foundPhone.Key == userSearch)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n✅ USUARIO ENCONTRADO ✅\n");
        Console.ResetColor();
        ShowContactFound(userSearch);
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("User not found.\n");
    }

}

// -----------------------------------------------------

void ModifyContact()
{
    Console.Clear();
    Console.WriteLine("------ WELCOME TO MODIFY CONTACT ------\n");
    Console.WriteLine($"                                          ✍️   List Contact Modify   ✍️                                                                      ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("________________________________________________________________________________");
    ShowAllContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
    Console.WriteLine("________________________________________________________________________________");
    Console.ResetColor();
    Console.WriteLine("\n                   👀 Enter the telephone to select the contact. 👀                   \n");
    Console.Write("\nWrite the Contact number you would like to modify: ");
    string optionNumber = Console.ReadLine()!;


    if (telephones.ContainsValue(optionNumber)) // Finish contact modification method.
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("that you want to modify of this contact");
        Console.ResetColor();
        ConfirmModifyContact(optionNumber);
    }
    else
    {
        Console.WriteLine("User not found.");
    }
}



void ConfirmDeleteContact()
{
    Console.Clear();
    Console.WriteLine("------ WELCOME TO REMOVE CONTACT ------\n");
    ShowAllContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

    Console.Write("Write the number: ");
    string optionNumber = Console.ReadLine()!;

    if (telephones.ContainsValue(optionNumber))
    {
        int IDNumber = telephonesInverted[optionNumber];
        Console.WriteLine("\n❎ you sure the delete this contact ❎\n");
        ShowContactFound(optionNumber);
        Console.WriteLine("1. SI\n2. NO\n");
        Console.Write("\nWrite your choose: ");

        Console.WriteLine("n1. YES   2. NO\n");
        Console.Write("write you option: ");
        bool optionBool = MultiOptionList.Contains(Console.ReadLine()!.ToLower());
        if (optionBool) { RemoveContact(IDNumber, optionNumber); }
        else
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Option invalid, select the option correct");
            Console.ReadKey();
            Console.ResetColor();
        }
    }

}


void RemoveContact(int IDNumber, string optionNumber)
{

    ids.Remove(IDNumber);
    names.Remove(IDNumber);
    lastnames.Remove(IDNumber);
    addresses.Remove(IDNumber);
    telephones.Remove(IDNumber);
    telephonesInverted.Remove(optionNumber);
    emails.Remove(IDNumber);
    ages.Remove(IDNumber);
    bestFriends.Remove(IDNumber);

    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nContact remove\n");
    Console.ResetColor();
    Console.WriteLine("press a key to continue....");
    Console.ReadLine();
}
// This Fuction Confirm the changes of contact

void ConfirmModifyContact(string optionNumber)
{
    ShowContactFound(optionNumber);
    int IDNumber = telephonesInverted[optionNumber];
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
                    names[IDNumber] = VerifyEmptyfield("modify name", "Angel");
                    lastnames[IDNumber] = VerifyEmptyfield("modify lastname", "Polanco");
            
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nChanges:\n\nName: {names[IDNumber]}\nLastname: {lastnames[IDNumber]}\n");
                    Console.ResetColor();
                    Console.ReadKey();
                    ShowContactFound(optionNumber);

                }
                break;
            case 2:
                {
                    addresses[IDNumber] = VerifyEmptyfield("modify address", "14 main street SC 19000");

                    bool optionBool = MultiOptionList.Contains(VerifyEmptyfield("new option of contact Isbesfriend: ", "yes").ToLower());
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
                    ShowContactFound(optionNumber);

                }
                break;
            case 3:
                {

                    emails[IDNumber] = VerifyEmptyfield("new email", "angel@dominio.com");
                    ages[IDNumber] = verifyAge("modify age");


                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nChanges:\n\nEmail: {emails[IDNumber]}\nAge: {ages[IDNumber]}\n");

                    Console.ResetColor();
                    Console.ReadKey();
                    ShowContactFound(optionNumber);
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

void ShowContactFound(string optionNumber)
{
    Console.WriteLine($"_______________________________________________________________________________________________\n");
    int IDNumber = telephonesInverted[optionNumber];
    bool isBestFriend = bestFriends[IDNumber];
    string isBestFriendStr = ShowMessageBesfriend(isBestFriend);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Select ✅ - {IDNumber}. Name: {names[IDNumber]} | lastname {lastnames[IDNumber]} | address: {addresses[IDNumber]} | telephone: {telephones[IDNumber]} | email: {emails[IDNumber]} | age: {ages[IDNumber]} | Is Best Friend: {isBestFriendStr}\n");
    Console.ResetColor();
}


// Show message in the fuction AddContact
void ConfirmContactShowMessage(string name, string lastname, string address, string phone, string email, int age, bool isBestFriend)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\n|| ------- CONFIRM IF THE DATA ENTERED IS CORRECT ------- ||\n");
    Console.ResetColor();

    string isBestFriendStr = ShowMessageBesfriend(isBestFriend);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"1. Name: {name}\n" + $"2. Lastname: {lastname}\n" + $"3. Address: {address}\n" + $"4. Phone: {phone}\n" + $"5. Email: {email}\n" + $"6. Age: {age}\n" + $"7. IsBestFriend: {isBestFriendStr}\n");
    Console.ResetColor();
    Console.WriteLine("Confirm with: [yes/no]");
}

static string ShowMessageBesfriend(bool isBestFriend)
{
    string isBestFriendStr = isBestFriend ? "YES" : "NO";
    return isBestFriendStr;
}

// ---------------------------------------------

static int verifyAge(string Typeinput)
{

    Console.Write("write the age of the person (only numbers): ");
    int.TryParse(Console.ReadLine(), out int age); // 10
    while (age <= 0 || age >= 120)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nYour age {age} is invalid. Please Enter a age valid\n");

        Console.ResetColor();
        Console.Write("Try of again (Enter a age valid): ");
        int.TryParse(Console.ReadLine(), out age);
    }

    return age; // 10
}

static bool ConfirmExit(bool option)
{
    bool runing = option ? false : true;
    return runing;
}
