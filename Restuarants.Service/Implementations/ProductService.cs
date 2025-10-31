using Restuarants.Core.CoreRepositories.ICoreRestuarantRepositories;
using Restuarants.Core.Enums;
using Restuarants.Core.Models;
using Restuarants.Data.DataMainRepositories;
using Restuarants.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Restuarants.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IRestuaranRepository _restuaranRepository = new MainReastuarantRepository();

        public async Task<string> Create(string RestuaranNo,string name,double price,ProductCategory pcategory)
        {
            Restuarant restuarant= await _restuaranRepository.GetAsync(x=>x.RestuarnatNo==RestuaranNo);
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Add again Product Name:");
                name = Console.ReadLine();
            }
            while (name == null)
            {
                Console.WriteLine("Add again Product Name:");
                name = Console.ReadLine();
            }
            while (price==null)
            {
                Console.WriteLine("Add again Product Price:");
                double.TryParse(Console.ReadLine(), out price);

            }
            Product product = new Product(restuarant,price,name,pcategory);
            restuarant.Products.Add(product);

            return "SuccesFully Product Created!!!";


        }

        public async Task<string> Delete(int id)
        {
            List<Restuarant> restuarants = await _restuaranRepository.GetAllAsync();
            foreach (Restuarant item in restuarants)
            {
                Product product = item.Products.Find(x => x.Id == id);
                if (product != null)
                {
                    item.Products.Remove(product);
                    Console.WriteLine("Succesfully Remowed");
                }

            }
            return "Student is not faund!!!";

        }

        public async Task<Product> Get(int id)
        {
            List<Restuarant> restuarants=await _restuaranRepository.GetAllAsync();
            foreach (var item in restuarants)
            {
                Product product=item.Products.Find(x => x.Id==id);
                if (product != null)
                {
                    return product;
                }

            }
            return null;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            List<Restuarant> restuarants=await _restuaranRepository.GetAllAsync();
            List<Product> products=new List<Product>();
            foreach (Restuarant item in restuarants)
            {
                products.AddRange(item.Products);
            }
            return products;
        }

        public async Task<string> Update(int id)
        {
            List<Restuarant> restuarants =await _restuaranRepository.GetAllAsync();
            foreach (Restuarant item in restuarants)
            {
                Product product = item.Products.Find(x=>x.Id==id);
                if (product != null)
                {
                    Console.WriteLine("Add Product Name:");
                    string name = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Add again Product Name:");
                        name = Console.ReadLine();
                    }
                    while (name == null)
                    {
                        Console.WriteLine("Add again Product Name:");
                        name = Console.ReadLine();
                    }
                    Console.WriteLine("Add Product Price:");
                    double.TryParse(Console.ReadLine(), out double price);
                    while (price == null)
                    {
                        Console.WriteLine("Add again Product Price:");
                        double.TryParse(Console.ReadLine(), out price);

                    }
                    Console.WriteLine("Choose the ProductCategory");
                    var PEnum = Enum.GetValues(typeof(ProductCategory));
                    foreach (var enums in PEnum)
                    {
                        Console.WriteLine((int)enums + "." + enums);
                    }
                    int.TryParse(Console.ReadLine(), out int pcategory);
                    try
                    {
                        PEnum.GetValue(pcategory - 1);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Product is not valid!!!");
                    }
                    product.Name=name;
                    product.Price=price;
                    return "Succesfully Updated";
                }
            }
            return "Restuarant is not faund";
        }
    }
}
