namespace N_Tier.Application.Models.Product
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }

    }
    public class CreateProductResponseModel : BaseResponseModel { }
}
