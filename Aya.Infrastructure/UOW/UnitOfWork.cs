using Aya.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;

namespace Aya.Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AyaDbContext context,
            IHttpContextAccessor httpContextAccessor,
            ICategoryRepository categoryRepository)
        {
            Categories = categoryRepository ?? new CategoryRepository(context, httpContextAccessor);
        }

        public ICategoryRepository Categories { get; }
    }
}
