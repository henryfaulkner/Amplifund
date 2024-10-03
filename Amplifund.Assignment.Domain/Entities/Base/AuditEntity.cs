using System;
using System.Collections.Generic;
using System.Text;

namespace Amplifund.Assignment.Domain.Entities.Base
{
    public class AuditEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
