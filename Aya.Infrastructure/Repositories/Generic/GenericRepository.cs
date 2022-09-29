using Aya.Infrastructure.Extensions;
using EFCore.BulkExtensions;
using LinqKit.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aya.Infrastructure.Repositories.Generic
{
    public abstract class GenericRepository<TSource> : IRepository<TSource> where TSource : class
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public virtual IQueryable<TSource> Queries
            => _context.Set<TSource>()
            .AsQueryable<TSource>()
            .AsNoTracking()
            .AsExpandable();

        public async virtual Task<bool> AnyAsync(Expression<Func<TSource, bool>> predicate = default!)
        {
            var query = _context.Set<TSource>().AsQueryable().AsNoTracking();

            return predicate == default
                ? await query.AnyAsync()
                : await query.AnyAsync(predicate);
        }

        public async virtual Task<TSource?> FirstOrDefaultAsync(
            Expression<Func<TSource, bool>> predicate,
            string include = default!
            )
        {
            var query = _context.Set<TSource>().AsQueryable<TSource>();
            return await query
                .BuildIncludeQuery(include)
                .AsExpandable()
                .Where(predicate)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public virtual IQueryable<TSource> Where(
            Expression<Func<TSource, bool>> predicate,
            string include = default!)
        {
            var query = _context.Set<TSource>().AsQueryable();
            return query
                .BuildIncludeQuery(include)
                .AsExpandable()
                .Where(predicate)
                .AsNoTracking();
        }

        public async virtual Task<TSource?> CreateAsync(TSource entity)
        {
            var result = await _context.Set<TSource>().AddAsync(entity);

            var rows = await _context.SaveChangesAsync();

            return rows > 0 ? result.Entity : null;
        }

        public async virtual Task BulkInsertAsync(IList<TSource> items)
        {
            await _context.BulkInsertAsync(items);
        }

        public async virtual Task UpdateAsync(TSource entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Set<TSource>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        public async virtual Task BulkUpdateAsync(IList<TSource> items)
        {
            await _context.BulkUpdateAsync(items);
        }

        public async virtual Task DeleteAsync(TSource entity)
        {
            _context.Set<TSource>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async virtual Task BulkDeleteAsync(IList<TSource> items)
        {
            await _context.BulkDeleteAsync(items);
        }
    }
}