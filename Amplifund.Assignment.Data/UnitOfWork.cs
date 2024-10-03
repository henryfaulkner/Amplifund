using System;
using System.Threading.Tasks;
using Amplifund.Assignment.Domain;

namespace Amplifund.Assignment.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChanges()
        {
            var numberOfEntries = await _context.SaveChangesAsync();
            return numberOfEntries > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
