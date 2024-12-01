using N_Tier.Application.Models;
using N_Tier.Application.Models.Employee;
using N_Tier.Core.Entities;

namespace N_Tier.Application.Services
{
    public interface IEmployeeService
    {
        public Task<CreateEmployeeResponseModel> CreateAsync(CreateEmployeeModel createEmployeeModel, CancellationToken cancellationToken = default);
        public Task<UpdateEmployeeResponseModel> UpdateAsync(Guid id, UpdateEmployeeModel updateProductResponseModel, CancellationToken cancellationToken = default);
        public Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<List<Employee>> GetAllAsyncWithQuerable();
        public Task<Employee> GetByIdAsync(Guid id);
    }
}
