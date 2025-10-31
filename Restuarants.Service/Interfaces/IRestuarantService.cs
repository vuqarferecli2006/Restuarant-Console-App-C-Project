using Restuarants.Core.Enums;
using Restuarants.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Restuarants.Service.Interfaces
{
    public interface IRestuarantService
    {
        public Task<string> Create( string name, string adress, RestuarantsCategory rcategory);
        public Task<string> Delete(int id);
        public Task<string> Update(int id, string name, string adress, RestuarantsCategory rcategory);
        public Task<Restuarant> Get(int id);
        public Task<List<Restuarant>> GetAllAsync();
        public Task<List<Product>> GetByIdProduct(int id);
    }
}
