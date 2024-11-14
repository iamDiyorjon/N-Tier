using AutoMapper;
using N_Tier.Application.Models.Customer;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CreateCustomerResponseMOdel> CreateAsync(CreateCustomerModel createCustomerModel, CancellationToken cancellationToken = default)
        {
            var customer = _mapper.Map<Customer>(createCustomerModel);

            return new CreateCustomerResponseMOdel
            {
                Id = (await _customerRepository.AddAsync(customer)).Id,
            };
        }

        public async Task<CustomerResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var customer = await _customerRepository.GetFirstAsync(c => c.Id == id);

            return new CustomerResponseModel
            {
                Id = (await _customerRepository.DeleteAsync(customer)).Id,
            };
        }

        public async Task<List<CustomerResponseModel>> GetAllAsyncWithQuerable()
        {
            var query = _customerRepository.GetAll().ToList();
            var result = _mapper.Map<List<CustomerResponseModel>>(query);

            return result;
        }

        public async Task<UpdateCustomerResponseModel> UpdateAsync(Guid id, UpdateCustomerModel updateCustomerModel, CancellationToken cancellationToken = default)
        {
            var customer = await _customerRepository.GetFirstAsync(c=>c.Id == id);
            _mapper.Map<Customer>(updateCustomerModel);

            return new UpdateCustomerResponseModel
            {
                Id = (await _customerRepository.UpdateAsync(customer)).Id
            };

        }
    }
}
