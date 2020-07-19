using DAL.Implementation.EF.Context;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Implementation.EF.Repositories
{
    public class EmployeesRepository : IBaseRepository<Employee>
    {
        private readonly AppContext _context;

        public EmployeesRepository(AppContext context)
        {
            _context = context;
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<Employee>> GetAllAsync()
            => await _context.Employees.AsNoTracking()
                                        .Include(x => x.Pet)
                                        .ToListAsync();

        ///<inheritdoc/>
        public async Task<Employee> GetByIdAsync(int id)
            => await _context.Employees.AsNoTracking()
                                    .Include(x => x.Pet)
                                    .FirstOrDefaultAsync(x => x.Id == id);

        ///<inheritdoc/>
        public async Task AddAsync(Employee entity)
        {
            await _context.Employees.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public Task UpdateAsync(Employee entity)
        {
            var employeeToUpdate = _context.Employees.Find(entity.Id);
            employeeToUpdate.FirstName = entity.FirstName;
            employeeToUpdate.LastName = entity.LastName;
            employeeToUpdate.MediaInteractivaEmployee = entity.MediaInteractivaEmployee;
            employeeToUpdate.Pet = entity.Pet;

            return _context.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            var employeeToDelete = _context.Employees.Find(id);

            if (employeeToDelete != null)
            {
                _context.Employees.Remove(employeeToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
