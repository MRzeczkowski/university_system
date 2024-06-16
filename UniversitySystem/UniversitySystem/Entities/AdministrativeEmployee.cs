using System;
using System.Collections.Generic;

namespace UniversitySystem.Entities;

public partial class AdministrativeEmployee
{
    public int EmployeeId { get; set; }

    public int PersonId { get; set; }

    public int DepartmentId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
