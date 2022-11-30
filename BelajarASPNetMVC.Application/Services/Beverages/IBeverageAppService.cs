using BelajarASPNetMVC.Application.Services.Beverages.Dto;
using BelajarASPNetMVC.Data.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Services.Beverages
{
    public interface IBeverageAppService
    {
        Beverage GetById(int id);
        Beverage GetByName(string name);
        IEnumerable<BeverageDto> GetBeverage();
        void Create(BeverageDto beverageDto);
        void Update(BeverageDto beverageDto);
        void Delete(int id);
    }
}
