
using Shared.Interfaces;
using Shared.Models;
using Shared.Services;
using System.Diagnostics;

namespace Assignment_Contacts_Part1.Services;

public class MenuService
{
    private readonly IContactService _contactService = new ContactService();

    public void ShowMainMenu()
    {
        while (true) 
        {
            Console.Clear();

            Console.WriteLine("CONTACT SERVICE");
            Console.WriteLine("What do you want to do?\n" +
                "1. Add Contact\n" +
                "2. Remove a Contact\n" +
                "3. Edit Contact\n" +
                "4. Show All Contacts\n" +
                "5. Quit\n");

            Console.Write("Choose an option (1-5): "); string decision = Console.ReadLine()!;

            switch (decision)
            {
                case "1":
                    ShowAddContactMenu();
                    break;

                case "2":
                    ShowRemoveContactMenu();
                    break;

                case "3":
                    ShowEditContactMenu();
                    break;

                case "4":
                    ShowAllContactsMenu();
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Please choose a valid option.");
                    break;
            }
        }
    }

    public void ShowAddContactMenu()
    {
        Console.Clear();
        Console.WriteLine("==ADD NEW CONTACT== \n");

        // Let user add contact information in console
        var request = new ContactCreateRequest();
        Console.Write("First Name: ");      request.FirstName     = Console.ReadLine()!;
        Console.Write("Last Name: ");       request.LastName      = Console.ReadLine()!;
        Console.Write("Phone Number: ");    request.PhoneNumber   = Console.ReadLine()!;
        Console.Write("E-Mail: ");          request.Email         = Console.ReadLine()!;

        Console.Write("Street Name: ");     request.Address.StreetName      = Console.ReadLine()!;
        Console.Write("Street Number: ");   request.Address.StreetNumber    = Console.ReadLine()!;
        Console.Write("Postal Code: ");     request.Address.PostalCode      = Console.ReadLine()!;
        Console.Write("City: ");            request.Address.City            = Console.ReadLine()!;

        _contactService.AddContact(request);

        Console.WriteLine("Contact successfully created!");
        Console.ReadKey();
    }

    public void ShowRemoveContactMenu()
    {
        Console.Clear();

        Console.Write("Please enter the e-mail address of the contact you'd like to edit: ");
        string email = Console.ReadLine()!;

        bool removeSuccessful = _contactService.DeleteContact(x => x.Email == email);

        string successMessage = removeSuccessful 
            ? "Removal successful!"
            : $"Removal failed: Contact with e-mail address \"{email}\" could not be found.";

        Console.WriteLine(successMessage);
        Console.ReadKey();
    }

    public void ShowEditContactMenu()
    {
        Console.Clear();

        try
        {
            Console.Write("Please enter the e-mail address of the contact you'd like to edit: ");
            string email = Console.ReadLine()!;

            var contact = _contactService.GetContact(x => x.Email == email);
            if (contact == null)
            {
                Console.WriteLine($"Edit failed: Contact with e-mail address \"{email}\" could not be found.");
                Console.ReadKey();
                return;
            }

            var request = new ContactEditRequest();
            Console.Write("New First Name: ");      request.FirstName = Console.ReadLine()!;
            Console.Write("New Last Name: ");       request.LastName = Console.ReadLine()!;
            Console.Write("New Phone Number: ");    request.PhoneNumber = Console.ReadLine()!;
            Console.Write("New E-Mail: ");          request.Email = Console.ReadLine()!;

            Console.Write("New Street Name: ");     request.Address.StreetName = Console.ReadLine()!;
            Console.Write("New Street Number: ");   request.Address.StreetNumber = Console.ReadLine()!;
            Console.Write("New Postal Code: ");     request.Address.PostalCode = Console.ReadLine()!;
            Console.Write("New City: ");            request.Address.City = Console.ReadLine()!;

            _contactService.EditContact(contact, request);

            Console.WriteLine("Contact successfully edited!");
            Console.ReadKey();
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
    }

    public void ShowAllContactsMenu()
    {
        Console.Clear();
        Console.WriteLine("==CURRENT CONTACTS==\n");
        try
        {
            var contactList = _contactService.GetContacts();

            int i = 1;
            foreach (var contact in contactList)
            {
                Console.WriteLine($"{i}.\n" +
                    $"Name: {contact.FirstName} {contact.LastName}\n" +
                    $"E-Mail: {contact.Email}\n" +
                    $"Phone: {contact.PhoneNumber}\n" +
                    $"Address: {contact.Address.StreetName} {contact.Address.StreetNumber}, {contact.Address.PostalCode} {contact.Address.City}\n");
                i++;
            }

            Console.ReadKey();
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
    }
}
