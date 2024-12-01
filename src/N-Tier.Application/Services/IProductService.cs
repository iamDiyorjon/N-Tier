using N_Tier.Application.Models.ProductModels;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Services
{
    public interface IProductService
    {
        public Task<CreateProductResponseModel> CreateAsync(CreateProductModel createProductModel, CancellationToken cancellationToken = default);
        public Task<UpdateProductResponseModel> UpdateAsync(Guid id, UpdateProductResponseModel updateProductResponseModel, CancellationToken cancellationToken = default);
        public Task<ProductResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<List<Product>> GetAllAsyncWithQuerable();
    }
}
