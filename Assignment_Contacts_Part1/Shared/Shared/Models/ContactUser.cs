using Shared.Interfaces;

namespace Shared.Models;

public class ContactUser : IContactUser
{
    public ContactUser() 
    {
        Id = Guid.NewGuid().ToString();
        FirstName = "";
        LastName = "";
        PhoneNumber = "";
        Email = "";
        Address = new AddressInfo();
    }

    public ContactUser(string firstName, string lastName, string phoneNumber, string email, IAddressInfo address) 
    {
        Id = Guid.NewGuid().ToString();
        FirstName = firstName ?? "";
        LastName = lastName ?? "";
        PhoneNumber = phoneNumber ?? "";
        Email = email ?? "";
        Address = address ?? new AddressInfo();
    }

    public string Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public IAddressInfo Address { get; set; } = null!;
}
