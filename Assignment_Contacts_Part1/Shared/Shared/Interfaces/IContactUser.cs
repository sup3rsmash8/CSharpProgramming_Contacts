namespace Shared.Interfaces;

public interface IContactUser
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string PhoneNumber { get; set; }
    string Email { get; set; }
    IAddressInfo Address { get; set; }
}
