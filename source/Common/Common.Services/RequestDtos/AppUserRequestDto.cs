namespace Common.Services.RequestDtos
{
    public record AppUserRequestDto : BaseDto
    {
        public string? Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public string? RoleId { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
