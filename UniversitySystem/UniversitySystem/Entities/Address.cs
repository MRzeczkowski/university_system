namespace UniversitySystem.Entities;

public class Address
{
    public int Id { get; init; }

    public string Street { get; init; } = null!;

    public int HouseNumber { get; init; }

    public int? FlatNumber { get; init; }

    public string City { get; init; } = null!;

    public string PostalCode { get; init; } = null!;

    public string Country { get; init; } = null!;

    public DateTime CreatedDate { get; init; }

    public DateTime? ModifiedDate { get; init; }

    public bool IsDeleted { get; init; }

    public virtual ApplicationUser User { get; init; } = null!;
}