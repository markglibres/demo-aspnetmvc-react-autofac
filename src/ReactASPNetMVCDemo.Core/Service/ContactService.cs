using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactASPNetMVCDemo
{
    public class ContactService : IContactService<ContactUs>
    {
        private readonly IRepository<ContactUs> _repo;

        public ContactService(IRepository<ContactUs> repository)
        {
            _repo = repository;
        }
        public async Task<ContactUs> AddAsync(string name, string email, string message)
        {
            var entity = new ContactUs()
            {
                Name = name,
                Email = email,
                Message = message
            };

            var result = await _repo.InsertAsync(entity);
            await _repo.SaveAsync();
            return result;

        }

        public async Task<IEnumerable<ContactUs>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }
    }
}
