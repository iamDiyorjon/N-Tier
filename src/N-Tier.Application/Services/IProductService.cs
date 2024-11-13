using N_Tier.Application.Models.ModelsByS.Category;
using N_Tier.Application.Models.TodoItem;
using N_Tier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace N_Tier.Application.Services.ServicesByS
{
    public interface IProductService
    {
        Task<CreateCategoryResponseModel> CreateAsync(CreateCategoryModel createCategoryModel,
       CancellationToken cancellationToken = default);
        Task<Models.ModelsByS.Product.ProductResponseModel> CreateAsync(Models.ModelsByS.Product.CreateProductModel createProductModel);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<TodoItemResponseModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateCategoryResponseModel> UpdateAsync(Guid id, UpdateCategoryModel updateCategoryModel,
            CancellationToken cancellationToken = default);
        Task<Models.ModelsByS.Product.UpdateProductModel> UpdateAsync(Guid id, Models.ModelsByS.Product.UpdateProductModel updateProductModel);
    }
}
