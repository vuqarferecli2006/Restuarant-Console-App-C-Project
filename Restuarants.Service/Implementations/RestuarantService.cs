using Restuarants.Core.CoreRepositories.ICoreRestuarantRepositories;
using Restuarants.Core.Enums;
using Restuarants.Core.Models;
using Restuarants.Data.DataMainRepositories;
using Restuarants.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Restuarants.Service.Implementations
{
    public class RestuarantService : IRestuarantService
    {
        private readonly  IRestuaranRepository _restuaranRepository=new MainReastuarantRepository();
        public async Task<string> Create(string name,string adress, RestuarantsCategory rcategory)
        {
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Add again Restuarant Name:");
                name = Console.ReadLine();
            }
            while (name==null)
            {
                Console.WriteLine("Add again Restuarant Name:");
                name = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(adress))
            {
                Console.WriteLine("Add again Restuarant Adress:");
                adress = Console.ReadLine();
            }
            while (adress == null)
            {
                Console.WriteLine("Add again Restuarant Adress:");
                adress = Console.ReadLine();
            }
            Restuarant restuarant=new Restuarant(rcategory, adress,name);
            await _restuaranRepository.AddAsync(restuarant);
            return "SuccesFuly Created";
        }

        public async Task<Restuarant> Get(int id)
        {
            Restuarant restuarant =await _restuaranRepository.GetAsync(x=>x.Id==id);
            if (restuarant==null)
            {
                Console.WriteLine("Restuarant is not valid!!!");
            }
            return restuarant;
        }
        public async Task<string> Delete(int id)
        {

            Restuarant restuarant = await _restuaranRepository.GetAsync(x=>x.Id==id);
            if (restuarant == null)
            {
                Console.WriteLine("Restuarant is not valid!!!");
            }
            await _restuaranRepository.RemoveAsync(restuarant);

            return "Succesfully Deleted";
        }


        public async Task<List<Restuarant>> GetAllAsync()
        {
            List<Restuarant> restuarants=await _restuaranRepository.GetAllAsync();
            return restuarants;
        }

        public async Task<List<Product>> GetByIdProduct(int id )
        {
            Restuarant restuarant = await _restuaranRepository.GetAsync(x=>x.Id==id);
            if (restuarant==null)
            {
                Console.WriteLine("Restuarant is not valid!!!");
                return null;
            }
            return restuarant.Products;
        }

        public async Task<string> Update(int id,string name,string adress, RestuarantsCategory rcategory)
        {
            Restuarant restuarant = await _restuaranRepository.GetAsync(x => x.Id == id);
            if (restuarant == null)
            {
                Console.WriteLine("Restuarant is not valid!!!");
                return null;
            }
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Add again Restuarant Name:");
                name = Console.ReadLine();
            }
            while (name == null)
            {
                Console.WriteLine("Add again Restuarant Name:");
                name = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(adress))
            {
                Console.WriteLine("Add again Restuarant Adress:");
                adress = Console.ReadLine();
            }
            while (adress == null)
            {
                Console.WriteLine("Add again Restuarant Adress:");
                adress = Console.ReadLine();
            }
            restuarant.Adress = adress;
            restuarant.Name = name;
            Restuarant restuarant1 = new Restuarant(rcategory, adress, name);
            await _restuaranRepository.UpdateAsync(restuarant1);
            return "Succesfully Updated";      
        }
    }
}
