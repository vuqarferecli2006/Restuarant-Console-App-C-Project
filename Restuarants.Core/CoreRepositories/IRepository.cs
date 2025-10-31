using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restuarants.Core.CoreRepositories
{
    public interface IRepository<T>
    {
        public Task AddAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task RemoveAsync(T entity);
        public Task<T> GetAsync(Func<T,bool> expression);
        public Task<List<T>> GetAllAsync();
    }
}
