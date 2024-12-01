using AutoMapper;
using N_Tier.Application.Models.ProductModels;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<CreateProductResponseModel> CreateAsync(CreateProductModel createProductModel, CancellationToken cancellationToken = default)
        {
            var category = await _categoryRepository.GetFirstAsync(c => c.Id == createProductModel.CategoryId);
            var product = _mapper.Map<Product>(createProductModel);
            product.Category = category;

            return new CreateProductResponseModel
            {
                Id = (await _productRepository.AddAsync(product)).Id
            };
        }

        public async Task<ProductResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.GetFirstAsync(p => p.Id == id);
            //typeof(Product).GetProperties();

            return new ProductResponseModel
            {
                Id = (await _productRepository.DeleteAsync(product)).Id
            };
        }


        public async Task<List<Product>> GetAllAsyncWithQuerable()
        {
            var query = _productRepository.GetAll();
            var result = query.ToList();
            return result;
        }

        public async Task<UpdateProductResponseModel> UpdateAsync(Guid id, UpdateProductResponseModel updateProductResponseModel, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.GetFirstAsync(p=>p.Id == id);
            _mapper.Map(updateProductResponseModel, product);

            return new UpdateProductResponseModel
            {
                Id = (await _productRepository.UpdateAsync(product)).Id
            };
        }
    }
}
