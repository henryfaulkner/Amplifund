using Amplifund.Assignment.Data.Repository.Base;
using Amplifund.Assignment.Domain.Entities.Grant;
using Amplifund.Assignment.Domain.IRepository.Grant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amplifund.Assignment.Data.Repository.Grant
{
    public class GrantRepository : BaseRepository<Domain.Entities.Grant.Grant>, IGrantRepository
    {
        private readonly AppDbContext _context;
        public GrantRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Grant.Grant> Get(long id)
        {
            return await _context.Grant
                .Where(x => x.Id == id)
                .FirstAsync();
        }
    }
}
