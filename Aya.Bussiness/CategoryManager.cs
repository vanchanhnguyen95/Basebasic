using Aya.Bussiness.Interface;
using Aya.Infrastructure.Models;
using Aya.Infrastructure.UOW;

namespace Aya.Bussiness
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Category?> CreateAsync(Category category)
        {
            return _unitOfWork.Categories.CreateAsync(category);
        }

        public Task<Category?> FindByIdAsync(Guid id)
        {
            return _unitOfWork.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}