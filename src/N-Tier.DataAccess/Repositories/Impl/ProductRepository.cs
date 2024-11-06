using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
