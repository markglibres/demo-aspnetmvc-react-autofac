using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactASPNetMVCDemo
{
    public interface IContactUs
    {
        string Name { get; set; }
        string Email { get; set; }
        string Message { get; set; }
    }
}
