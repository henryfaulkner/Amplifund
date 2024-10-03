using Amplifund.Assignment.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amplifund.Assignment.Domain.Entities.Grant
{
    public class Grant : AuditEntity
    {
        [Key]
        public long Id { get; set; }
        public string RefNumber { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool IsDeleted { get; set; }
    }
}
