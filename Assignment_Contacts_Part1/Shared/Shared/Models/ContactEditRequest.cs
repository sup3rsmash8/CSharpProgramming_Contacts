using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

/// <summary>
/// Class that serves as a request for a contact service to 
/// edit a contact and give them new properties.
/// </summary>
public class ContactEditRequest
{
    public ContactEditRequest()
    {
        FirstName = "";
        LastName = "";
        PhoneNumber = "";
        Email = "";
        Address = new AddressInfo();
    }

    public ContactEditRequest(string firstName, string lastName, string phoneNumber, string email, string streetName, string streetNumber, string postalCode, string city)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = new AddressInfo
        {
            StreetName = streetName,
            StreetNumber = streetNumber,
            PostalCode = postalCode,
            City = city,
        };
    }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public IAddressInfo Address { get; set; } = null!;
}

