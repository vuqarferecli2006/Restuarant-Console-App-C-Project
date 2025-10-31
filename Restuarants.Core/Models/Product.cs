using Restuarants.Core.Enums;
using Restuarants.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restuarants.Core.Models
{
    public class Product:BaseModel
    {
        public static int _id;
        public double Price {  get; set; }
        public ProductCategory PCategory { get; set; }
        public Restuarant Restuarants { get; set; }
        public Product(Restuarant restuarants,double price,string name,ProductCategory productCategory)
        {
            _id++;
            Id = _id;
            Restuarants = restuarants;
            Price = price;
            Name = name;
            PCategory = productCategory;

        }
    }
}
