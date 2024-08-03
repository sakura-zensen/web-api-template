namespace Common.Infrastructure.Entities
{
    public record BaseEntity
    {
        public bool Sys_Deactivated { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
