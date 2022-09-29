using Aya.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aya.Services.Interface
{
    public interface ICategoryService
    {
        Task<CategoryModel> FindByIdAsync(Guid id);
    }
}
