using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ReactASPNetMVCDemo
{
    public class GenericRepository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet _set;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.Run(() => _set.OfType<T>().AsQueryable());
        }

        public async Task<T> GetByIdAsync<TKey>(TKey id)
        {
            return await _set.OfType<T>().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<T> InsertAsync(T entity)
        {
            var result =  await Task.Run(() =>  _set.Add(entity) );
            return result as T;

        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => _context.Entry<T>(entity).State = EntityState.Modified);  
        }
    }
}
