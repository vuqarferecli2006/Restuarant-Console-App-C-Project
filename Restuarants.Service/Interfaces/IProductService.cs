using Restuarants.Core.Enums;
using Restuarants.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restuarants.Service.Interfaces
{
    public interface IProductService
    {
        public Task<string> Create(string RestuaranNo, string name, double price, ProductCategory pcategory );
        public Task<string> Delete(int id);
        public Task<string> Update(int id);
        public Task<Product> Get(int id);
        public Task<List<Product>> GetAllAsync();
    }
}
