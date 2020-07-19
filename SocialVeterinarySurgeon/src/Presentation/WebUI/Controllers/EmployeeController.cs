using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeesService _employeService;

        public EmployeeController(IEmployeesService employeeService)
        {
            _employeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync() 
            => Ok(await _employeService.GetAllEmployeesAsync());

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            if (id <= 0)
                return BadRequest("Wrong employee id");

            var employee = await _employeService.GetEmployeeByIdAsync(id);
            if (employee == null)
                return NotFound($"There is no employee with {id} id");

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Employee employee)
        {
            if (employee == null)
                return BadRequest("Wrong employee data");

            await _employeService.UpsertEmployeeAsync(employee);

            if (employee.Id == 0)
                return Created("/v1/employee", employee);
            else
                return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _employeService.DeleteEmployeeAsync(id);

            return NoContent();
        }
    }
}
