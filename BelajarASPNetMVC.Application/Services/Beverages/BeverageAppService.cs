using AutoMapper;
using BelajarASPNetMVC.Application.Services.Beverages.Dto;
using BelajarASPNetMVC.Data;
using BelajarASPNetMVC.Data.Databases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Services.Beverages
{
    public class BeverageAppService : IBeverageAppService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public BeverageAppService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(BeverageDto beverageDto)
        {
            var beverage = _mapper.Map<Beverage>(beverageDto);
            _context.Beverage.Add(beverage);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var beverage = _context.Beverage.AsNoTracking().FirstOrDefault(w => w.Id == id);

            if (beverage != null)
            {
                var deletedData = _mapper.Map<BeverageDto>(beverage);
                deletedData.IsDeleted = true;
                Update(deletedData);
            }
        }

        public IEnumerable<BeverageDto> GetBeverage()
        {
            var data = _context.Beverage.AsQueryable().Where(w => w.IsDeleted == false);

            return _mapper.Map<IEnumerable<BeverageDto>>(data);
        }

        public Beverage GetById(int id)
        {
            return _context.Beverage.FirstOrDefault(w => w.Id == id);
        }

        public Beverage GetByName(string name)
        {
            return _context.Beverage.FirstOrDefault(w => w.Title == name);
        }

        public void Update(BeverageDto beverageDto)
        {
            var beverage = _mapper.Map<Beverage>(beverageDto);
            _context.Beverage.Update(beverage);
            _context.SaveChanges();
        }
    }
}
