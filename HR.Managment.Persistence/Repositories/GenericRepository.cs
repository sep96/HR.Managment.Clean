using HR.Managment.Application.Contracts.Persistence;
using HR.Managment.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly HrDatabaseContext _dBContext;
        public GenericRepository(HrDatabaseContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dBContext.AddAsync(entity);
            await _dBContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await GetByIDAsync(id);
             _dBContext.Remove(entity);
            await _dBContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dBContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await _dBContext.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dBContext.Update(entity);
            await _dBContext.SaveChangesAsync();
            return entity;
        }
    }
}
