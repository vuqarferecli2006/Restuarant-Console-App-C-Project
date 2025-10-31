using Restuarants.Core.CoreRepositories;
using Restuarants.Core.Models;
using Restuarants.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restuarants.Data.DataMainRepositories
{
    public class MainRepository<T> : IRepository<T> where T : BaseModel
    {
        private readonly List<T> _items=new List<T>();
        public List<T> Items { get { return _items; } }

        public async Task AddAsync(T entity)
        {
            Items.Add(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return Items;
        }

        public async Task<T> GetAsync(Func<T, bool> expression)
        {
            return Items.FirstOrDefault(expression);
        }

        public async Task RemoveAsync(T entity)
        {
            Items.Remove(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Id == entity.Id)
                {
                    Items[i] = entity;
                }
            }
        }
    }
}
