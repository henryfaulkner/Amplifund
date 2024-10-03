using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amplifund.Assignment.Domain.Entities.Common;
using Amplifund.Assignment.Domain.IRepository.Common;
using Amplifund.Assignment.Logger;
using Microsoft.Extensions.Logging;

// Usually, I would map the database entities to response models (from Amplifund.Assignment.Model) via AutoMapper or ORM-technology or manually,
// but for the sake of time, I will just be POSTing and GETing the entities directly.
namespace Amplifund.Assignment.BL.Common.Interactor
{
    public class CommonInteractor : ICommonInteractor
    {
        private readonly ILogger<CommonInteractor> _logger;
        private readonly IStateRepository _stateRepository;

        public CommonInteractor(ILogger<CommonInteractor> logger, IStateRepository stateRepository)
        {
            _logger = logger;
            _stateRepository = stateRepository;
        }

        public async Task<List<State>> GetStates()
        {
            try
            {
                _logger.LogInformation("Start GetStates");
                var result = (await _stateRepository.GetAll()).ToList();
                _logger.LogInformation("End GetStates");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
