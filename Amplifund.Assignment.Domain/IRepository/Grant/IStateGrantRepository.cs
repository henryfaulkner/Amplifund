using Amplifund.Assignment.Domain.Entities.Grant;
using Amplifund.Assignment.Domain.IRepository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amplifund.Assignment.Domain.IRepository.Grant
{
    public interface IStateGrantRepository : IBaseRepository<StateGrant>
    {
        Task<List<StateGrant>> GetStateGrantsByState(int stateId);
        Task<StateGrant> Get(long id);
        Task<List<StateGrant>> GetByGrantId(long grantId);
    }
}
