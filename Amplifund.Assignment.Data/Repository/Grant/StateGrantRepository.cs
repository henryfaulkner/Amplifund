using Amplifund.Assignment.Data.Repository.Base;
using Amplifund.Assignment.Domain.Entities.Grant;
using Amplifund.Assignment.Domain.IRepository.Grant;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Amplifund.Assignment.Domain.Entities.Common;

namespace Amplifund.Assignment.Data.Repository.Grant
{
    public class StateGrantRepository : BaseRepository<StateGrant>, IStateGrantRepository
    {
        private readonly AppDbContext _context;
        public StateGrantRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<StateGrant>> GetStateGrantsByState(int stateId)
        {
            return await _context.StateGrant
                .Where(x => x.StateId == stateId)
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<StateGrant> Get(long id)
        {
            return await _context.StateGrant
                .Where(x => x.Id == id)
                .FirstAsync();
        }

        public async Task<List<StateGrant>> GetByGrantId(long grantId)
        {
            return await _context.StateGrant
                .Where(x => x.GrantId == grantId)
                .ToListAsync();
        }
    }
}
