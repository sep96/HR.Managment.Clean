using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T :  class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIDAsync(int id);
        Task<T> AddAsync(T entity); 
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);    
    }
}
