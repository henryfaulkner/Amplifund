using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amplifund.Assignment.Domain.Entities.Common;

namespace Amplifund.Assignment.BL.Common.Interactor
{
    public interface ICommonInteractor
    {
        Task<List<State>> GetStates();
    }
}
