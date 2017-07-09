using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactASPNetMVCDemo
{
    public interface IAuditableEntity
    {
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
    }
}
