using Aya.Infrastructure.Base;
using Microsoft.AspNetCore.Http;

namespace Aya.Infrastructure.Repositories.Generic
{
    public abstract class GenericPersistentTrackedRepository<TSource>
        : GenericRepository<TSource> where TSource
        : class, ITrackedEntity, IPersistentEntity
    {
        private readonly HttpContext _httpContext;

        protected GenericPersistentTrackedRepository(AyaDbContext context, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        protected string CurrentUser => _httpContext.User.Identity != null
                                     && _httpContext.User.Identity.IsAuthenticated
                                     ? _httpContext.User.Identity.Name ?? "Unknown"
                                     : "Unknown";

        public async override Task<TSource?> CreateAsync(TSource entity)
        {
            entity.CreatedDate = DateTime.Now;
            if (string.IsNullOrEmpty(entity.CreatedBy))
            {
                entity.CreatedBy = CurrentUser;
            }

            entity.LastUpdatedDate = DateTime.Now;
            if (string.IsNullOrEmpty(entity.LastUpdatedBy))
            {
                entity.LastUpdatedBy = CurrentUser;
            }

            entity.DeletedAt = null;
            return await base.CreateAsync(entity);
        }

        public async override Task UpdateAsync(TSource entity)
        {
            entity.LastUpdatedDate = DateTime.Now;
            if (string.IsNullOrEmpty(entity.LastUpdatedBy))
            {
                entity.LastUpdatedBy = CurrentUser;
            }

            await base.UpdateAsync(entity);
        }

        public async override Task BulkUpdateAsync(IList<TSource> items)
        {
            if (items == null || !items.Any()) return;

            await base.BulkUpdateAsync(
                items.Select(
                    x =>
                    {
                        x.LastUpdatedBy = CurrentUser;
                        x.LastUpdatedDate = DateTime.Now;
                        return x;
                    }).ToList()
            );
        }

        public override async Task BulkInsertAsync(IList<TSource> items)
        {
            await base.BulkInsertAsync(
                items.Select(
                    x =>
                    {
                        x.LastUpdatedDate = DateTime.Now;
                        x.LastUpdatedBy = CurrentUser;
                        x.CreatedDate = DateTime.Now;
                        x.CreatedBy = CurrentUser;
                        return x;
                    }).ToList()
           );
        }

        public override async Task DeleteAsync(TSource entity)
        {
            if (entity == null) return;

            entity.IsDeleted = true;
            entity.DeletedAt = DateTime.Now;
            entity.LastUpdatedBy = CurrentUser;
            entity.LastUpdatedDate = DateTime.Now;

            await UpdateAsync(entity);
        }

        public override async Task BulkDeleteAsync(IList<TSource> items)
        {
            if (items == null || !items.Any()) return;

            await BulkUpdateAsync(
                items.Select(
                    x =>
                    {
                        x.IsDeleted = true;
                        x.DeletedAt = DateTime.Now;
                        return x;
                    }).ToList()
           );
        }
    }
}
