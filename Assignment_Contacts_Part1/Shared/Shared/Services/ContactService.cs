using Shared.Interfaces;
using Shared.Models;
using System.Collections;
using System.Diagnostics;

namespace Shared.Services;

public class ContactService : IContactService
{
    public ContactService()
    {
        // Try load the list from file first. If this fails,
        // create a new list object instead.
        if (!TryLoadContactListFromFile())
        {
            _contacts = new List<ContactUser>();
        }
    }

    private static readonly string _pathToContactFile = @"c:\ContactService";
    private static readonly string _contanctFileName = "contact_list.json";
    private List<ContactUser> _contacts = new List<ContactUser>();

    public void AddContact(ContactCreateRequest contactCreateRequest)
    {
        try
        {
            var contact = new ContactUser(
                contactCreateRequest.FirstName, 
                contactCreateRequest.LastName, 
                contactCreateRequest.PhoneNumber, 
                contactCreateRequest.Email, 
                contactCreateRequest.Address);
            _contacts.Add(contact);

            // Update the list file to reflect changes.
            SaveListToFile();
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
    }

    public void EditContact(IContactUser contact, ContactEditRequest contactEditRequest) 
    {
        try
        {
            var listContact = GetContact(x => x == contact)!;

            listContact.FirstName = contactEditRequest.FirstName;
            listContact.LastName = contactEditRequest.LastName;
            listContact.PhoneNumber = contactEditRequest.PhoneNumber;
            listContact.Email = contactEditRequest.Email;
            listContact.Address = contactEditRequest.Address;

            // Update the list file to reflect changes.
            SaveListToFile();
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
    }

    public bool DeleteContact(System.Func<IContactUser, bool> expression)
    {
        var contact = GetContact(expression) as ContactUser;

        bool result = contact != null && _contacts.Remove(contact);
        if (result)
        {
            // Update the list file to reflect changes.
            SaveListToFile();
        }

        return result;
    }

    public IContactUser? GetContact(System.Func<IContactUser, bool> expression)
    {
        try
        {
            return _contacts.FirstOrDefault(expression);
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null;
    }

    public IEnumerable<IContactUser> GetContacts()
    {
        // Try loading from file first, if possible.
        TryLoadContactListFromFile();
        return _contacts;
    }

    /// <summary>
    /// Short-hand function to save the list to a file.
    /// </summary>
    private void SaveListToFile()
    {
        FileManager.SaveObjectToJsonFile(_pathToContactFile, _contanctFileName, _contacts);
    }

    /// <summary>
    /// Tries to load the contact list from the JSON file. If this succeeds, the contact list will be replaced 
    /// with the list found in the file and returns true. If this fails, nothing happens to the list and the 
    /// function returns false.
    /// </summary>
    private bool TryLoadContactListFromFile()
    {
        var list = FileManager.GetJsonObjectFromFile<List<ContactUser>>(@$"{_pathToContactFile}\{_contanctFileName}");
        if (list != null) 
        {
            _contacts = list;
            return true;
        }

        return false;
    }
}
