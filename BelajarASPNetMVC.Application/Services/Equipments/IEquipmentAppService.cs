using BelajarASPNetMVC.Application.Services.Equipments.Dto;
using BelajarASPNetMVC.Data.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Services.Equipments
{
    public interface IEquipmentAppService
    {
        Equipment GetById(int id);
        Equipment GetByName(string name);
        IEnumerable<EquipmentDto> GetEquipment();
        void Create(EquipmentDto EquipmentDto);
        void Update(EquipmentDto EquipmentDto);
        void Delete(int id);
    }
}
