using Amplifund.Assignment.Domain;
using Amplifund.Assignment.Domain.Entities.Grant;
using Amplifund.Assignment.Domain.IRepository.Grant;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Usually, I would map the database entities to response models (from Amplifund.Assignment.Model) via AutoMapper or ORM-technology or manually,
// but for the sake of time, I will just be POSTing and GETing the entities directly.
namespace Amplifund.Assignment.BL.Grants.Interactor
{
    public class GrantsInteractor : IGrantsInteractor
    {
        private readonly ILogger<GrantsInteractor> _logger;
        private readonly IGrantRepository _grantRepository; 
        private readonly IStateGrantRepository _stateGrantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GrantsInteractor(ILogger<GrantsInteractor> logger, IGrantRepository grantRepository, IStateGrantRepository stateGrantRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _grantRepository = grantRepository;
            _stateGrantRepository = stateGrantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Grant> CreateGrant(string refNumber, string name, decimal amount)
        {
            try
            {
                _logger.LogInformation("Start CreateGrant");
                var entity = new Grant();
                entity.RefNumber = refNumber;
                entity.Name = name;
                entity.Amount = amount;
                await _grantRepository.Add(entity);
                await _unitOfWork.SaveChanges();
                _logger.LogInformation("End CreateGrant");
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<StateGrant> CreateStateGrant(string refNumber, string name, decimal amount, int stateId)
        {
            try
            {
                _logger.LogInformation("Start CreateStateGrant");
                var grant = await CreateGrant(refNumber, name, amount);
                var entity = new StateGrant();
                entity.GrantId = grant.Id;
                entity.StateId = stateId;
                await _stateGrantRepository.Add(entity);
                await _unitOfWork.SaveChanges();
                _logger.LogInformation("End CreateStateGrant");
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<Grant> UpdateGrantAmount(long grantId, decimal newAmount)
        {
            try
            {
                _logger.LogInformation("Start UpdateGrantAmount");
                var result = await _grantRepository.Get(grantId);
                result.Amount = newAmount;
                await _unitOfWork.SaveChanges();
                _logger.LogInformation("End UpdateGrantAmount");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<List<Grant>> GetGrants()
        {
            try
            {
                _logger.LogInformation("Start GetGrants");
                var result = (await _grantRepository.GetAll())
                    .Where(x => x.IsDeleted == false) // only putting the where here for time purposes
                    .ToList();
                _logger.LogInformation("End GetGrants");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<List<StateGrant>> GetStateGrants()
        {
            try
            {
                _logger.LogInformation("Start GetStateGrants");
                var result = (await _stateGrantRepository.GetAll())
                    .Where(x => x.IsDeleted == false) // only putting the where here for time purposes
                    .ToList();
                _logger.LogInformation("End GetStateGrants");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<List<StateGrant>> GetStateGrantsByState(int stateId)
        {
            try
            {
                _logger.LogInformation("Start GetStateGrantsByState");
                var result = await _stateGrantRepository.GetStateGrantsByState(stateId);
                _logger.LogInformation("End GetStateGrantsByState");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<Grant> DeleteGrant(long grantId)
        {
            try
            {
                _logger.LogInformation("Start DeleteGrant");
                var result = await _grantRepository.Get(grantId);
                result.IsDeleted = true;
                var relatedStateGrants = await _stateGrantRepository.GetByGrantId(grantId);
                relatedStateGrants.ForEach(x => x.IsDeleted = true);
                await _unitOfWork.SaveChanges();
                _logger.LogInformation("End DeleteGrant");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }


        public async Task<StateGrant> DeleteStateGrant(long stateGrantId)
        {
            try
            {
                _logger.LogInformation("Start DeleteStateGrant");
                var result = await _stateGrantRepository.Get(stateGrantId);
                await _unitOfWork.SaveChanges();
                _logger.LogInformation("End DeleteStateGrant");
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
