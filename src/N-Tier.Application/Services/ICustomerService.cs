using N_Tier.Application.Models.CustomerModels;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Services
{
    public interface ICustomerService
    {
        public Task<CreateCustomerResponseModel> CreateAsync(CreateCustomerModel createCustomerModel , CancellationToken cancellationToken = default);
        public Task<UpdateCustomerResponseModel> UpdateAsync(Guid id, UpdateCustomerModel updateCustomerModel , CancellationToken cancellationToken = default);
        public Task<CustomerResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<List<CustomerResponseModel>> GetAllAsyncWithQuerable();
    }
}
