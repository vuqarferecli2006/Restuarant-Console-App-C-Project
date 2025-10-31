using Restuarants.Core.Enums;
using Restuarants.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restuarants.Core.Models
{
    public class Restuarant:BaseModel
    {
        public static int _id;
        public string Adress { get; set; }
        public string RestuarnatNo {  get; set; }
        public List<Product> Products;
        public RestuarantsCategory Category { get; set; }

        public Restuarant(RestuarantsCategory category,string adress,string name)
        {
            _id++;
            Id = _id;
            Category=category;
            Name = name;
            Adress = adress;
            RestuarnatNo = $"{category.ToString()[0]}-0{Id}";
            Products = new List<Product>();

        }
        public override string ToString()
        {
            return $"Id:{Id}  Name:{Name}  Adress:{Adress}  Category:{Category} RestuarantNo:{RestuarnatNo}" ;
        }

    }
}
