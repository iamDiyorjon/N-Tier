using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;
using N_Tier.DataAccess.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Services.Impl
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
