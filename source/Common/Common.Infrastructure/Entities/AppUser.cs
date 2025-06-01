using Microsoft.AspNetCore.Identity;

namespace Common.Infrastructure.Entities;

public class AppUser : IdentityUser
{
    private readonly BaseEntity baseEntity = new();

    [PersonalData]
    [MaxLength(100)]
    [Required]
    public string? FirstName { get; set; }

    [PersonalData]
    [MaxLength(100)]
    public string? LastName { get; set; }

    public bool Sys_Deactivated { get; set; }

    public DateTime CreatedDate
    {
        get { return baseEntity.CreatedDate; }
        set { }
    }
    public DateTime? UpdatedDate
    {
        get { return baseEntity.UpdatedDate; }
        set { baseEntity.UpdatedDate = value; }
    }
}
