namespace UniversitySystem.Entities;

public class Address
{
    public int Id { get; set; }

    public string Street { get; set; } = null!;

    public int HouseNumber { get; set; }

    public int? FlatNumber { get; set; }

    public string City { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
