using AutoMapper;
using Aya.Bussiness.Interface;
using Aya.Models.Category;
using Aya.Services.Interface;

namespace Aya.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryManager _categoryManager;

        public CategoryService(ICategoryManager categoryManager, IMapper mapper)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
        }

        public async Task<CategoryModel> FindByIdAsync(Guid id)
        {
            var category = await _categoryManager.FindByIdAsync(id);

            return _mapper.Map<CategoryModel>(category);
        }
    }
}