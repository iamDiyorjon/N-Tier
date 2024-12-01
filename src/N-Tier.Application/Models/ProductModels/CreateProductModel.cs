using N_Tier.Core.Entities;

namespace N_Tier.Application.Models.ProductModels;

public class CreateProductModel
{
    public string Name { get; set; }
    public Guid CategoryId { get; set; }

    public static explicit operator CreateProductModel (Product prodduct)
    {
        return new CreateProductModel
        {
            Name = prodduct.Name,
            CategoryId = prodduct.CategoryId
        };
    }

}
public class CreateProductResponseModel : BaseResponseModel { }
