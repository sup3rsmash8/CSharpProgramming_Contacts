using Shared.Models;

namespace Shared.Interfaces;

public interface IContactService
{
    /// <summary>
    /// Adds a contact.
    /// </summary>
    void AddContact(ContactCreateRequest contactCreateRequest);

    /// <summary>
    /// Edits the information of a contact.
    /// </summary>
    void EditContact(IContactUser contact, ContactEditRequest contactEditRequest);

    /// <summary>
    /// Removes a contact in the contact list that matches the 
    /// conditions in the provided expression. Returns whether 
    /// this was successful or not.
    /// </summary>
    bool DeleteContact(System.Func<IContactUser, bool> expression);

    /// <summary>
    /// Returns a contact in the contact list that matches the 
    /// conditions in the provided expression.
    /// </summary>
    IContactUser? GetContact(System.Func<IContactUser, bool> expression);

    /// <summary>
    /// Returns a list of contacts added to the list.
    /// </summary>
    IEnumerable<IContactUser> GetContacts();
}
