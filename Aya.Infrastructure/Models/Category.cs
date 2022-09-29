using Aya.Infrastructure.Base;

namespace Aya.Infrastructure.Models
{
    public record Category : BaseTrackedEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
