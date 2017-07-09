using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactASPNetMVCDemo
{
    public class AuditableEntity : BaseEntity, IAuditableEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
