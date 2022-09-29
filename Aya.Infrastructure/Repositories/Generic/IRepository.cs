using System.Linq.Expressions;

namespace Aya.Infrastructure.Repositories.Generic
{
    public interface IRepository<TSource>
    {
        IQueryable<TSource> Queries { get; }

        Task<bool> AnyAsync(Expression<Func<TSource, bool>> predicate = default!);

        Task<TSource?> FirstOrDefaultAsync(Expression<Func<TSource, bool>> predicate, string include = default!);

        IQueryable<TSource> Where(Expression<Func<TSource, bool>> predicate, string include = default!);

        Task<TSource?> CreateAsync(TSource entity);

        Task BulkInsertAsync(IList<TSource> items);

        Task UpdateAsync(TSource entity);

        Task BulkUpdateAsync(IList<TSource> items);

        Task DeleteAsync(TSource entity);

        Task BulkDeleteAsync(IList<TSource> items);
    }
}
