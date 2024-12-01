namespace N_Tier.Application.Models.ProductModels
{
    public class UpdateProductModel
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
    public class UpdateProductResponseModel : BaseResponseModel { }
}
