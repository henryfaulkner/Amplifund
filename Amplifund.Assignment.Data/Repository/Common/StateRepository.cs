using Amplifund.Assignment.Data.Repository.Base;
using Amplifund.Assignment.Domain.Entities.Common;
using Amplifund.Assignment.Domain.IRepository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amplifund.Assignment.Data.Repository.Common
{
    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        private readonly AppDbContext _context;
        public StateRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
