namespace N_Tier.Application.Models;

public class CreateOrderDetailsModel
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}

