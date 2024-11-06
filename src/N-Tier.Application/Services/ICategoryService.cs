using N_Tier.Application.Models;
using N_Tier.Application.Models.Category;
using N_Tier.Core.Entities;

namespace N_Tier.Application.Services
{
    public interface ICategoryService
    {
        Task<CreateCategoryResponseModel> CreateaAsync(CreateCategoryModel createCategoryModel);
        Task<BaseResponseModel> DeleteAsync(Guid id);
        Task<UpdateCategoryResponseModel> UpdateAsync(Guid id, UpdateCategoryModel updateCategoryModel);
        Task<List<Category>> GetAllWithIQueryableAsync();
    }
}
