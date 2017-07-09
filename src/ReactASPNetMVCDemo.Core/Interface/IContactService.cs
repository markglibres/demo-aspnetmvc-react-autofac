using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactASPNetMVCDemo
{
    public interface IContactService<T> where T: BaseEntity
    {
        Task<T> AddAsync(string name, string email, string message);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
