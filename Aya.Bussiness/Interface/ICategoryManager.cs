using Aya.Infrastructure.Models;

namespace Aya.Bussiness.Interface
{
    public interface ICategoryManager
    {
        Task<Category?> FindByIdAsync(Guid id);
        Task<Category?> CreateAsync(Category category);
    }
}
