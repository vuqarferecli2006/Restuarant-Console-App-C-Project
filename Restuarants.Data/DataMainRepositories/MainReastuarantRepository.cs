using Restuarants.Core.CoreRepositories.ICoreRestuarantRepositories;
using Restuarants.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restuarants.Data.DataMainRepositories
{
    public class MainReastuarantRepository:MainRepository<Restuarant>,IRestuaranRepository
    {
    }
}
