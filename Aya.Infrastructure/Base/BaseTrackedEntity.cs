namespace Aya.Infrastructure.Base
{
    public record BaseTrackedEntity : IPersistentEntity, ITrackedEntity
    {
        public string CreatedBy { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; } = default!;
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
