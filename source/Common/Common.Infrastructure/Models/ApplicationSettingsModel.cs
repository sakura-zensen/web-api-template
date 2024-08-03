namespace Common.Services.Models
{
    public class ApplicationSettingsModel
    {
        public const string ApplicationSettings = nameof(ApplicationSettings);
        public required string JwtSecret { get; set; } = string.Empty;
        public required string ClientUrl { get; set; } = string.Empty;
    }
}
