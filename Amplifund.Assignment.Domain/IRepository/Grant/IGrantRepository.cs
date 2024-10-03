using Amplifund.Assignment.Domain.Entities.Grant;
using Amplifund.Assignment.Domain.IRepository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amplifund.Assignment.Domain.IRepository.Grant
{
    public interface IGrantRepository : IBaseRepository<Entities.Grant.Grant>
    {
        Task<Entities.Grant.Grant> Get(long id);
    }
}
