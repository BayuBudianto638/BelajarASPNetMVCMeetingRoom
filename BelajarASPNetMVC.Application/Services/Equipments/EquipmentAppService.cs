using AutoMapper;
using BelajarASPNetMVC.Application.Services.Beverages.Dto;
using BelajarASPNetMVC.Application.Services.Equipments.Dto;
using BelajarASPNetMVC.Data;
using BelajarASPNetMVC.Data.Databases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Services.Equipments
{
    public class EquipmentAppService : IEquipmentAppService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public EquipmentAppService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public void Create(EquipmentDto EquipmentDto)
        {
            var equipment = _mapper.Map<Equipment>(EquipmentDto);
            _context.Equipment.Add(equipment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var equipment = _context.Equipment.AsNoTracking().FirstOrDefault(w => w.Id == id);

            if (equipment != null)
            {
                var deletedData = _mapper.Map<EquipmentDto>(equipment);
                deletedData.IsDeleted = true;
                Update(deletedData);
            }
        }

        public Equipment GetById(int id)
        {
            return _context.Equipment.FirstOrDefault(w => w.Id == id);
        }

        public Equipment GetByName(string name)
        {
            return _context.Equipment.FirstOrDefault(w => w.Title == name);
        }

        public IEnumerable<EquipmentDto> GetEquipment()
        {
            var data = _context.Equipment.AsQueryable().Where(w => w.IsDeleted == false);

            return _mapper.Map<IEnumerable<EquipmentDto>>(data);
        }

        public void Update(EquipmentDto EquipmentDto)
        {
            var equipment = _mapper.Map<Equipment>(EquipmentDto);
            _context.Equipment.Update(equipment);
            _context.SaveChanges();
        }
    }
}
