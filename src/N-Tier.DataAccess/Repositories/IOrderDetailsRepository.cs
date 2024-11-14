using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.DataAccess.Repositories
{
    public interface IOrderDetailsRepository
    {
        Task<OrderDetails> GetFirstAsync(Expression<Func<OrderDetails, bool>> predicate);

        Task<List<OrderDetails>> GetAllAsync(Expression<Func<OrderDetails, bool>> predicate);

        Task<OrderDetails> AddAsync(OrderDetails entity);

        Task<OrderDetails> UpdateAsync(OrderDetails entity);

        Task<OrderDetails> DeleteAsync(OrderDetails entity);
    }
}
