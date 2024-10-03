using System;
using System.Threading.Tasks;

namespace Amplifund.Assignment.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveChanges();
    }
}
