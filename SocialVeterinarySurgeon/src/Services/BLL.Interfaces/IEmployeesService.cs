using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEmployeesService
    {
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>employees list</returns>
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        /// <summary>
        /// Get employee by id
        /// </summary>
        /// <param name="id">employee id</param>
        /// <returns>employee</returns>
        Task<Employee> GetEmployeeByIdAsync(int id);

        /// <summary>
        /// Add/update employee
        /// </summary>
        /// <param name="employee">employe to add/update</param>
        Task UpsertEmployeeAsync(Employee employee);

        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="id">employee to delete id</param>
        Task DeleteEmployeeAsync(int id);
    }
}
