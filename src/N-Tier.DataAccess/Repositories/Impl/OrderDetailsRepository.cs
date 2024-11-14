using Microsoft.EntityFrameworkCore;
using N_Tier.Core.Entities;
using N_Tier.Core.Exceptions;
using N_Tier.DataAccess.Persistence;
using System.Linq.Expressions;

namespace N_Tier.DataAccess.Repositories.Impl
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        protected readonly DatabaseContext Context;
        protected readonly DbSet<OrderDetails> DbSet;

        public OrderDetailsRepository(DatabaseContext context)
        {
            Context = context;
            DbSet = context.Set<OrderDetails>();
        }

        public async Task<OrderDetails> AddAsync(OrderDetails entity)
        {
            var addedEntity = (await DbSet.AddAsync(entity)).Entity;
            await Context.SaveChangesAsync();

            return addedEntity;
        }

        public async Task<OrderDetails> DeleteAsync(OrderDetails entity)
        {
            var removedEntity = DbSet.Remove(entity).Entity;
            await Context.SaveChangesAsync();

            return removedEntity;
        }

        public async Task<List<OrderDetails>> GetAllAsync(Expression<Func<OrderDetails, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<OrderDetails> GetFirstAsync(Expression<Func<OrderDetails, bool>> predicate)
        {
            var entity = await DbSet.Where(predicate).FirstOrDefaultAsync();

            if (entity == null) throw new ResourceNotFoundException(typeof(OrderDetails));

            return await DbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<OrderDetails> UpdateAsync(OrderDetails entity)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync();

            return entity;
        }
    }
}
