using Shared.Interfaces;

namespace Shared.Models;

/// <summary>
/// Class that contains info about an address, presumably a contact's.
/// </summary>
public class AddressInfo : IAddressInfo
{
    public AddressInfo() 
    {
        StreetName = "";
        StreetNumber = "";
        PostalCode = "";
        City = "";
    }

    public AddressInfo(string streetName, string streetNumber, string postalCode, string city)
    {
        StreetName = streetName ?? "";
        StreetNumber = streetNumber ?? "";
        PostalCode = postalCode ?? "";
        City = city ?? "";
    }

    public string StreetName { get; set; } = null!;
    public string StreetNumber { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
}
