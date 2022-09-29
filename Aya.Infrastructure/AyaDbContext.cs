using Aya.Infrastructure.Extensions;
using Aya.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aya.Infrastructure
{
    public class AyaDbContext : IdentityDbContext<User, Role, Guid>
    {
        public AyaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.FilterDeletedRecords();
            base.OnModelCreating(builder);
        }
    }
}
