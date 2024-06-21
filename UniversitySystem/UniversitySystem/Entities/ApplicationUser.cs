using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace UniversitySystem.Entities;

public class ApplicationUser : IdentityUser<long>
{
    public int? PersonId { get; set; }

    [ForeignKey("PersonId")]
    public virtual Person Person { get; set; }
}