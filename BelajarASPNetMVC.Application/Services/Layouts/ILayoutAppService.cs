using BelajarASPNetMVC.Application.Services.Layouts.Dto;
using BelajarASPNetMVC.Data.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Services.Layouts
{
    public interface ILayoutAppService
    {
        Layout GetById(int id);
        Layout GetByName(string name);
        IEnumerable<Layout> GetLayout();
        int GetCapacity(int capacity);
        LayoutDto GetPriceLayout(int Id);
        void Create(LayoutDto layout);
        List<LayoutDto> GetLayoutImage();
        LayoutDto GetLayoutImageById(int id);
        void Update(LayoutDto layoutDto);
        void Delete(int id);
    }
}
