using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactASPNetMVCDemo
{
    public interface IRepository<T>
    {
        Task<T> InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync<TKey>(TKey id);
        Task SaveAsync();
    }
}
