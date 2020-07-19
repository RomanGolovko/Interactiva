using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Implementation
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IBaseRepository<Employee> _employeesRepo;

        public EmployeesService(IBaseRepository<Employee> employeesRepository)
        {
            _employeesRepo = employeesRepository;
        }

        ///<inheritdoc/>
        public Task<IEnumerable<Employee>> GetAllEmployeesAsync()
            => _employeesRepo.GetAllAsync();

        ///<inheritdoc/>
        public Task<Employee> GetEmployeeByIdAsync(int id)
            => _employeesRepo.GetByIdAsync(id);

        ///<inheritdoc/>
        public async Task UpsertEmployeeAsync(Employee employee)
        {
            if (employee.Id == 0)
                await _employeesRepo.AddAsync(employee);
            else
                await _employeesRepo.UpdateAsync(employee);
        }

        ///<inheritdoc/>
        public Task DeleteEmployeeAsync(int id)
            => _employeesRepo.DeleteAsync(id);
    }
}
