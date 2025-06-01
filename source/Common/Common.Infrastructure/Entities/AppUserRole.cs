using Microsoft.AspNetCore.Identity;

namespace Common.Infrastructure.Entities;

public class AppUserRole : IdentityRole
{
    private readonly BaseEntity baseEntity = new();

    [MaxLength(50)]
    public required string DisplayName { get; set; }

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
