using Restuarants.Service.Implementations;
using Restuarants.Service.Interfaces;

IMenuServices menuServices=new MenuService();

await menuServices.ShowMenuAsync();
