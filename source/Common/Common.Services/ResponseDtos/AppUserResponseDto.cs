namespace Common.Services.ResponseDtos;

public record AppUserResponseDto
{
    public AppUser? User { get; set; }
    public string? RoleId { get; set; }
    public string? Role { get; set; }
    public bool? Sys_Deactivated { get; set; }
}
public record AppUserInfoResponseDto
{
    public string? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Role { get; set; }
}
