using DAL.Implementation.EF.Context;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Implementation.EF.Repositories
{
    public class PetsRepository : IBaseRepository<Pet>
    {
        private readonly AppContext _context;

        public PetsRepository(AppContext context)
        {
            _context = context;
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<Pet>> GetAllAsync()
            => await _context.Pets.AsNoTracking().ToListAsync();

        ///<inheritdoc/>
        public async Task<Pet> GetByIdAsync(int id)
            => await _context.Pets.AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == id);

        ///<inheritdoc/>
        public Task AddAsync(Pet entity)
        {
            _context.Pets.AddAsync(entity);

            return _context.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public Task UpdateAsync(Pet entity)
        {
            var petToUpdate = _context.Pets.Find(entity.Id);
            petToUpdate.Name = entity.Name;
            petToUpdate.Type = entity.Type;
            petToUpdate.OwnerId = entity.OwnerId;

            return _context.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            var petToDelete = _context.Employees.Find(id);

            if (petToDelete != null)
            {
                _context.Employees.Remove(petToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
