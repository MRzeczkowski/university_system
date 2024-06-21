namespace UniversitySystem.Entities;

public partial class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public int AddressId { get; set; }

    public int GenderId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<AdministrativeEmployee> AdministrativeEmployees { get; set; } =
        new List<AdministrativeEmployee>();

    public virtual Gender Gender { get; set; } = null!;

    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}