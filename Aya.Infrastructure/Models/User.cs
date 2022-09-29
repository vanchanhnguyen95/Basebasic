using Aya.Infrastructure.Base;
using Microsoft.AspNetCore.Identity;

namespace Aya.Infrastructure.Models
{
    public class User : IdentityUser<Guid>, IPersistentEntity, ITrackedEntity
    {
        public string Surname { get; set; } = default!;
        public string GivenName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public DateTime? LastLogin { get; set; }
        public string CreatedBy { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; } = default!;
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}