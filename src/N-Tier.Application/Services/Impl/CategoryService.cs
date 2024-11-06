using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Category;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;
using N_Tier.Shared.Services;

namespace N_Tier.Application.Services.Impl
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;

        public CategoryService(IClaimService claimService, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _claimService = claimService;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CreateCategoryResponseModel> CreateaAsync(CreateCategoryModel createCategoryModel)
        {
            var category = _mapper.Map<Category>(createCategoryModel);

            return new CreateCategoryResponseModel
            {
                Id = (await _categoryRepository.AddAsync(category)).Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id)
        {
            var category = await _categoryRepository.GetFirstAsync(c => c.Id == id);

            return new BaseResponseModel
            {
                Id = (await _categoryRepository.DeleteAsync(category)).Id
            };
        }

        public async Task<List<Category>> GetAllWithIQueryableAsync()
        {
            var categories = _categoryRepository.GetAll();
            var result = categories.ToList();

            return result;
        }

        public async Task<UpdateCategoryResponseModel> UpdateAsync(Guid id, UpdateCategoryModel updateCategoryModel)
        {
            var category = await _categoryRepository.GetFirstAsync(c => c.Id == id);
            _mapper.Map<Category>(updateCategoryModel);

            return new UpdateCategoryResponseModel
            {
                Id = (await _categoryRepository.UpdateAsync(category)).Id
            };
        }
    }
}
