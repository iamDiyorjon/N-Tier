using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Employee;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<CreateEmployeeResponseModel> CreateAsync(CreateEmployeeModel createEmployeeModel, CancellationToken cancellationToken = default)
        {
            var employee = _mapper.Map<Employee>(createEmployeeModel);
            return new CreateEmployeeResponseModel
            {
                Id = (await _employeeRepository.AddAsync(employee)).Id,
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var employee = await _employeeRepository.GetFirstAsync(e => e.Id == id);
            return new BaseResponseModel
            {
                Id = (await _employeeRepository.DeleteAsync(employee)).Id,
            };
        }

        public async Task<List<Employee>> GetAllAsyncWithQuerable()
        {
            var employees = _employeeRepository.GetAll().ToList();
            return employees;
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetFirstAsync(e => e.Id == id);
            return employee;
        }

        public async Task<UpdateEmployeeResponseModel> UpdateAsync(Guid id, UpdateEmployeeModel updateEmployeeModel , CancellationToken cancellationToken = default)
        {
            var employee = await _employeeRepository.GetFirstAsync(e => e.Id == id);
            _mapper.Map(employee, updateEmployeeModel);
            return new UpdateEmployeeResponseModel
            {
                Id = (await _employeeRepository.UpdateAsync(employee)).Id
            };
        }
    }
}
