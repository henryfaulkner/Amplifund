using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amplifund.Assignment.Domain.IRepository.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task<bool> SaveRepository();
    }
}
