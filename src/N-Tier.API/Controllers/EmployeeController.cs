using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Employee;
using N_Tier.Application.Services;
using N_Tier.Core.Entities;

namespace N_Tier.API.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateEmployeeModel createEmployeeModel)
        {
            return Ok(ApiResult<CreateEmployeeResponseModel>.Success(
               await _employeeService.CreateAsync(createEmployeeModel)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponseModel>.Success(
                await _employeeService.DeleteAsync(id)));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateEmployeeModel updateEmployeeModel)
        {
            return Ok(ApiResult<BaseResponseModel>.Success(
                await _employeeService.UpdateAsync(id, updateEmployeeModel)));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(ApiResult<Employee>.Success(
                await _employeeService.GetByIdAsync(id)));
        }
    }
}
