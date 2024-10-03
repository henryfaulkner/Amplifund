using Amplifund.Assignment.Domain.Entities.Base;
using Amplifund.Assignment.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amplifund.Assignment.Domain.Entities.Grant
{
    public class StateGrant : AuditEntity
    {
        [Key]
        public long Id { get; set; }
        public long GrantId { get; set; }
        public int StateId { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(GrantId))]
        public Grant Grant { get; set; }
        [ForeignKey(nameof(StateId))]
        public State State { get; set; }
    }
}
