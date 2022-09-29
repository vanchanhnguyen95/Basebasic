using Aya.Infrastructure.Models;
using Aya.Infrastructure.Repositories.Generic;
using Microsoft.AspNetCore.Http;

namespace Aya.Infrastructure.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }

    public class CategoryRepository : GenericPersistentTrackedRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AyaDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
