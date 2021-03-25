using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrimbleAPI.Models;
using TrimbleAPI.Services;

namespace TrimbleAPI.Controllers
{
    [ApiController]
    [Route(template: "[controller]")]
    public class EmployeesController:ControllerBase
    {
        IEmployeeCollectionService _employeeCollectionService;


        public EmployeesController(IEmployeeCollectionService employeeCollectionService)
        {
            _employeeCollectionService = employeeCollectionService ?? throw new ArgumentNullException(nameof(employeeCollectionService));
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            List<Employee> employees = await _employeeCollectionService.GetAll();
            if (employees.Count == 0)
            {
                return NoContent();
            }
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee cannot be null");
            }
            await _employeeCollectionService.Create(employee);
            return Ok(employee);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] Employee employee)
        {
            bool isUpdated = await _employeeCollectionService.Update(id,employee);
            if (!isUpdated)
            {
                return NotFound();
            }


            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            bool isDeleted = await _employeeCollectionService.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok();
        }


        [HttpGet("{teamLeaderId}")]
        public async Task<IActionResult> GetEmployeeByTeamLeaderId(Guid teamLeaderId)
        {
            List<Employee> employees = await _employeeCollectionService.GetEmployeeByTeamLeaderId(teamLeaderId);
            if (employees.Count == 0)
            {
                return NoContent();
            }
            return Ok(employees);
        }

    }
}

