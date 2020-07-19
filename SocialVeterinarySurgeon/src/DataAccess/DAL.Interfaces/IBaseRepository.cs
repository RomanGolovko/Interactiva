using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Get all entities from db
        /// </summary>
        /// <returns>list of entities</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Get entity by id from db
        /// </summary>
        /// <param name="id">entity id</param>
        /// <returns>searched entity</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Add entity to db
        /// </summary>
        /// <param name="entity"></param>
        Task AddAsync(T entity);

        /// <summary>
        /// Update entity in db
        /// </summary>
        /// <param name="entity">entity for update</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Delete entity from db
        /// </summary>
        /// <param name="id">entity id</param>
        Task DeleteAsync(int id);
    }
}
