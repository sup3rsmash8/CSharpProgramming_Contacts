namespace Shared.Interfaces;

public interface IAddressInfo
{
    string StreetName { get; set; }
    string StreetNumber { get; set; }
    string PostalCode { get; set; }
    string City { get; set; }
}
