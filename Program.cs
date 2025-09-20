using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

Console.WriteLine("Bienvenido a mi lista de Contactes");


//names, lastnames, addresses, telephones, emails, ages, bestfriend
bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

List<(int id, string Name, string Lastname, string Address, string Phone, string Email, int Age, int Temp, string IsBestFriend)> NewContactTemp = new List<(int id, string name, string lastname, string address, string phone, string email, int age, int temp, string isBestFriend)>();


while (runing)
{
    Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   6. Eliminar Contacto    6. Salir");
    Console.WriteLine("Digite el número de la opción deseada");

    int typeOption = Convert.ToInt32(Console.ReadLine());

    switch (typeOption)
    {
        case 1:
            {

                Console.WriteLine("Digite el nombre de la persona");
                string name = Console.ReadLine()!;
                Console.WriteLine("Digite el apellido de la persona");
                string lastname = Console.ReadLine()!;
                Console.WriteLine("Digite la dirección");
                string address = Console.ReadLine()!;
                Console.WriteLine("Digite el telefono de la persona");
                string phone = Console.ReadLine()!;
                Console.WriteLine("Digite el email de la persona");
                string email = Console.ReadLine()!;
                Console.WriteLine("Digite la edad de la persona en números");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");
                var temp = Convert.ToInt32(Console.ReadLine());
                bool isBestFriend;

                isBestFriend = (temp == 1) ? true : false;

                string isBestFriendYesOrNot = (isBestFriend == true) ? "Si" : "NO";

                var id = ids.Count + 1;
                NewContactTemp.Add((
                    Id: id,
                    Name: name,
                    Lastname: lastname,
                    Address: address,
                    Phone: phone,
                    Email: email,
                    Age: age,
                    Temp: temp,
                    IsBestFriend: isBestFriendYesOrNot
                ));

                AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 2: //extract this to a method
            {
                Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
                Console.WriteLine($"____________________________________________________________________________________________________________________________");
                foreach (var id in ids)
                {
                    var isBestFriend = bestFriends[id];

                    string isBestFriendStr = (isBestFriend == true) ? "Si" : "No";
                    Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
                }

            }
            break;
        case 3: //search
            { }
            break;
        case 4: //modify
            { }
            break;
        case 5: //delete
            { }
            break;
        case 6:
            runing = false;
            break;
        default:
            Console.WriteLine("Tu eres o te haces el idiota?");
            break;
    }
}


void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{

    Console.WriteLine("|| CONFIRMA SI LOS DATOS INTRODUCIDOS SON CORRECTOS (RESPONDE 1. SI O 2. NO)||\n");

    Console.WriteLine($"\nNombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
    Console.WriteLine($"____________________________________________________________________________________________________________________________");

    for (int i = 0; i < NewContactTemp.Count; i++)
    {
        Console.WriteLine($"es I: {i} ((( ))) LISTA: {NewContactTemp[i]}");
        var contant = NewContactTemp[i];
        Console.WriteLine($"{contant.Name}         {contant.Lastname}         {contant.Address}         {contant.Phone}            {contant.Email}            {contant.Age}          {contant.IsBestFriend}");

    }

    Console.WriteLine("Salio del bucle ✅");

    Console.Write("Ingrese el numero correspondiente: ");
    int optionform = int.Parse(Console.ReadLine()!);
    Console.WriteLine("Entrara al if");

    var date_contant = NewContactTemp[0];
    int id = date_contant.id;
    string phone = date_contant.Phone;

    if (optionform == 1 && !telephones.ContainsValue(date_contant.Phone))
    {
        telephones.Add(id, phone);
        Console.WriteLine($"Se guardo en la contact list ✅ // telefonos: {telephones}");

        //var id = ids.Count + 1;
        //ids.Add(id);
        //names.Add(id, name);
        //lastnames.Add(id, lastname);
        //addresses.Add(id, address);
        //emails.Add(id, email);
        //ages.Add(id, age);
        //bestFriends.Add(id, isBestFriend);
    }
    else if (optionform == 2)
    {
        Console.Clear();
        Console.WriteLine("Limpiando lista ");
        NewContactTemp.Clear();
        return;
    }

    else
    {
        Console.WriteLine();
    }
}
