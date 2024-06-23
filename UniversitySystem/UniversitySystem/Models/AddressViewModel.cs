namespace UniversitySystem.Models;

public class AddressViewModel
{
    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int HouseNumber { get; set; }

    public int? FlatNumber { get; set; }
}