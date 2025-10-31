using Restuarants.Core.CoreRepositories.ICoreRestuarantRepositories;
using Restuarants.Core.Enums;
using Restuarants.Core.Models;
using Restuarants.Data.DataMainRepositories;
using Restuarants.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Restuarants.Service.Implementations
{
    public class MenuService : IMenuServices
    {
        private readonly IRestuarantService _restuarantService=new RestuarantService();
        private readonly IProductService _productService=new ProductService();
        public async Task ShowMenuAsync()
        {
            await Show();
            int.TryParse(Console.ReadLine(),out int request);
            while (request !=0)
            {
                switch (request)
                {
                    case 1:
                        Console.Clear();
                        await CreateRestuarant();
                        break;
                    case 2:
                        Console.Clear();
                        await ShowAllRestuarant();
                        break;
                    case 3:
                        Console.Clear();
                        await ShowRestuarant();
                        break;
                    case 4:
                        Console.Clear();
                        await UpdateRestuarant();
                        break;
                    case 5:
                        Console.Clear();
                        await RemoveRestuarant();
                        break;
                    case 6:
                        Console.Clear();
                        await CreateProduct();
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    default:
                        Console.WriteLine("Choose valid option!!!");
                        break;
                }
                await Show();
                int.TryParse(Console.ReadLine(),out request);
            }
        }

        private async Task Show()
        {
            Console.WriteLine("1.Create Restaurant");
            Console.WriteLine("2.Show All Restaurant");
            Console.WriteLine("3.Get Restaurant By Id");
            Console.WriteLine("4.Update Restaurant");
            Console.WriteLine("5.Remove Restaurant");
            Console.WriteLine("6.Create Product");
            Console.WriteLine("7.Show All Product");
            Console.WriteLine("8.Get Product By Id");
            Console.WriteLine("9.Update Product");
            Console.WriteLine("10.Remove Product");
            Console.WriteLine("0.Close Console");
        }
        private async Task CreateRestuarant()
        {
            Console.WriteLine("Add Restuarant Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Add Restuarant Adress:");
            string adress = Console.ReadLine();

            var Enums = Enum.GetValues(typeof(RestuarantsCategory));
            Console.WriteLine("Choose the Category:");
            foreach (var category in Enums)
            {
                Console.WriteLine((int)category + "." + category);
            }

            int.TryParse(Console.ReadLine(), out int rcategory);

            try
            {
                Enums.GetValue(rcategory - 1);
            }
            catch (Exception)
            {
                Console.WriteLine("Category is not valid!!!");
            }
            string message=await _restuarantService.Create(name, adress,(RestuarantsCategory) rcategory);
            Console.WriteLine(message);
        }
        private async Task ShowAllRestuarant()
        {
            List<Restuarant> restuarants=await _restuarantService.GetAllAsync();
            foreach (var item in restuarants)
            {
                Console.WriteLine(item);
            }
        }
        private async Task ShowRestuarant()
        {
            Console.WriteLine("Enter Id");
            int.TryParse(Console.ReadLine(),out int id);
            Restuarant restuarant=await _restuarantService.Get(id);
            Console.WriteLine(restuarant);

        }
        private async Task UpdateRestuarant()
        {
            Console.WriteLine("Enter Id");
            int.TryParse(Console.ReadLine(),out int id);
            Console.WriteLine("Add Restuarant Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Add Restuarant Adress:");
            string adress = Console.ReadLine();
            var Enums = Enum.GetValues(typeof(RestuarantsCategory));
            Console.WriteLine("Choose the Category:");
            foreach (var category in Enums)
            {
                Console.WriteLine((int)category + "." + category);
            }
            int.TryParse(Console.ReadLine(), out int rcategory);
            try
            {
                Enums.GetValue(rcategory - 1);
            }
            catch (Exception)
            {
                Console.WriteLine("Category is not valid!!!");
            }
            string message = await _restuarantService.Update(id,name,adress,(RestuarantsCategory) rcategory);
            Console.WriteLine(message);
        }
        private async Task RemoveRestuarant()
        {
            Console.WriteLine("Enter Id");
            int.TryParse(Console.ReadLine(),out int id);
            string message=await _restuarantService.Delete(id);
            Console.WriteLine(message);

        }


        private async Task CreateProduct()
        {
            Console.WriteLine("Enter RestuarantNo");
            string restuarantno=Console.ReadLine();

            Console.WriteLine("Add Product Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Add Product Price:");
            double.TryParse(Console.ReadLine(), out double price);

            Console.WriteLine("Choose the ProductCategory");
            var PEnum = Enum.GetValues(typeof(ProductCategory));
            foreach (var item in PEnum)
            {
                Console.WriteLine((int)item + "." + item);
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
            string message = await _productService.Create(restuarantno,name,price,(ProductCategory)pcategory);
            Console.WriteLine(message);
        }

    }
}
