using CRUD.Domain.Models.Entities.Info;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl
{
    public class RegionRepository : BaseRepository<Region>, IRegionRepository
    {
        public RegionRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }
    }
}
