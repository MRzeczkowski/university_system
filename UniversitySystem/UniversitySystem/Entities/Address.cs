namespace UniversitySystem.Entities;

public class Address
{
    public int Id { get; init; }

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int HouseNumber { get; set; }

    public int? FlatNumber { get; set; }

    public long UserId { get; set; }

    public virtual ApplicationUser User { get; init; } = null!;
}