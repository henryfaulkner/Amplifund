using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amplifund.Assignment.Domain.IRepository.Base;
using Microsoft.EntityFrameworkCore;

namespace Amplifund.Assignment.Data.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private AppDbContext _context;
        public BaseRepository(AppDbContext appDBContext)
        {
            _context = appDBContext;

        }
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public async Task<bool> SaveRepository()
        {
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
