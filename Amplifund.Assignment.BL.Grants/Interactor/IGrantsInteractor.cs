using Amplifund.Assignment.Domain.Entities.Grant;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amplifund.Assignment.BL.Grants.Interactor
{
    public interface IGrantsInteractor
    {
        public Task<Grant> CreateGrant(string refNumber, string name, decimal amount);
        public Task<StateGrant> CreateStateGrant(string refNumber, string name, decimal amount, int stateId);

        Task<Grant> UpdateGrantAmount(long id, decimal newAmount);

        Task<List<Grant>> GetGrants();
        Task<List<StateGrant>> GetStateGrants();
        Task<List<StateGrant>> GetStateGrantsByState(int stateId);

        Task<Grant> DeleteGrant(long grantId);
        Task<StateGrant> DeleteStateGrant(long stateGrantId);
    }
}
