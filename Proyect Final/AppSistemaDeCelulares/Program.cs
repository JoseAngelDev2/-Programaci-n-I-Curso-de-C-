using System;
using AppSistemaDeCelulares.Data;
using AppSistemaDeCelulares.Helpers;
using AppSistemaDeCelulares.Helpers.Forms;
using AppSistemaDeCelulares.Helpers.Registers;
using AppSistemaDeCelulares.Helpers.Seed;
using AppSistemaDeCelulares.Views;
using AppCustomer =  AppSistemaDeCelulares.Data.ApplicationDbContext;

AppCustomer _context = new AppCustomer();

DatabaseSeeder Showdata = new DatabaseSeeder(_context);
await Showdata.SeedAllData();


while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔══════════════════════════════════════════════╗");
            Console.WriteLine("║           SYSTEM CELL PHONES — MENU          ║");
            Console.WriteLine("╚══════════════════════════════════════════════╝\n");

            Console.ResetColor();

            void Panel(string title, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.WriteLine("┌────────────────────────────────────────────┐");
                Console.WriteLine($"│  {title.PadRight(42)}│");
                Console.WriteLine("└────────────────────────────────────────────┘");
                Console.ResetColor();
            }

            void Option(string number, string text)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"   [{number}] {text}");
            }

            Panel("REGISTRATION MODULE", ConsoleColor.DarkCyan);
            Option("1", "Register Customer");
            Option("2", "Register Phone Device");
            Option("3", "Show All Customers");
            Option("4", "Show All Phones");

            Console.WriteLine();

            Panel("EDIT & DELETE MODULE", ConsoleColor.DarkYellow);
            Option("5", "Edit Customer");
            Option("6", "Edit Phone Device");
            Option("7", "Delete Record");

            Console.WriteLine();

            Panel("SERVICE MODULE", ConsoleColor.DarkGreen);
            Option("8", "Register Diagnostic");
            Option("9", "Register Repair");
            Option("10", "Register Delivery");

            Console.WriteLine();

            Panel("HISTORY", ConsoleColor.DarkMagenta);
            Option("11", "Show Phone History");

            Console.WriteLine();

            Panel("SYSTEM", ConsoleColor.DarkRed);
            Option("12", "Exit");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("➜ Select an option: ");
            Console.ResetColor();

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await FormCustomers.FormCustomer();
                    break;

                case "2":
                    await FormPhoneDevices.FormPhoneDevice();
                    break;

                case "3":
                    ShowViews.ShowAllCustomers(_context);
                    break;

                case "4":
                    ShowAllPhones.ShowPhones();
                    break;

                case "5":
                    await FormEditCustomer.EditCustomer();
                    
                    break;

                case "6":
                    await EditDevice.FormEditDevice();
                    break;

                case "7":
                    await DeleteRecord.FromDeleteRecord();
                    break;

                case "8":
                    await RegisterDiagnostic.FormRegisterDiagnostic();
                    break;

                case "9":
                    await RegisterRepairDetail.FormRegisterRepairDetail();
                    break;

                case "10": 
                    await FormRegisterDeliverys.FormRegisterDelivery();
                    break;

                case "11":
                    await ShowPhoneHistoryHelper.ShowPhoneHistory(_context);
                    break;

                case "12":
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid option. Press ENTER...");
                    Console.ReadLine();
                    break;
            }
        }
    

