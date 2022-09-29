using Microsoft.EntityFrameworkCore;

namespace Aya.Infrastructure.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<T> BuildIncludeQuery<T>(this IQueryable<T> query, string include) where T : class
        {
            if (!string.IsNullOrWhiteSpace(include))
            {
                var includeEntities = include.Split(',').ToList();

                includeEntities.ForEach(entity => query = query.Include(entity));
            }

            return query;
        }
    }
}