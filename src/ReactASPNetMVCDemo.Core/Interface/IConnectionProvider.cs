using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactASPNetMVCDemo
{
    public interface IConnectionProvider
    {
        string ConnectionString { get; set; }
    }
}
