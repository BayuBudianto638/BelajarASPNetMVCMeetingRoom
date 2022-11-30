using AutoMapper;
using BelajarASPNetMVC.Application.Services.Layouts.Dto;
using BelajarASPNetMVC.Data;
using BelajarASPNetMVC.Data.Databases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Services.Layouts
{
    public class LayoutAppService : ILayoutAppService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LayoutAppService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(LayoutDto layout)
        {
            var Layout = _mapper.Map<Layout>(layout);
            _context.Layout.Add(Layout);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // select * from layout [nolock] where id=id
            var Layout = _context.Layout.AsNoTracking().FirstOrDefault(w => w.Id == id);

            if (Layout != null)
            {
                var deletedData = _mapper.Map<LayoutDto>(Layout);
                deletedData.IsDeleted = true;
                Update(deletedData);
            }
        }

        public Layout GetById(int id)
        {
            return _context.Layout.FirstOrDefault(w => w.Id == id);
        }

        public Layout GetByName(string name)
        {
            return _context.Layout.FirstOrDefault(w => w.LayoutTitle == name);
        }

        public int GetCapacity(int id)
        {
            var result = _context.Layout.FirstOrDefault(w => w.Id == id);

            return result.Id;
        }

        public IEnumerable<Layout> GetLayout()
        {
            var data = _context.Layout.AsQueryable().Where(w => w.IsDeleted == false);

            return _mapper.Map<IEnumerable<Layout>>(data);
        }

        public List<LayoutDto> GetLayoutImage()
        {
            var layoutList = (from a in _context.Layout
                        where a.IsDeleted == false
                        select new LayoutDto
                        {
                            Id = a.Id,
                            LayoutTitle = a.LayoutTitle,
                            LayoutImages = a.LayoutImages
                        }).ToList();

            return layoutList;
        }

        public LayoutDto GetLayoutImageById(int id)
        {
            var layout = (from a in _context.Layout
                        where a.Id == id && a.IsDeleted == false
                        select new LayoutDto
                        {
                            Id = a.Id,
                            LayoutTitle = a.LayoutTitle,
                            LayoutCapacity = a.LayoutCapacity.Value,
                            LayoutImages = a.LayoutImages
                        }).FirstOrDefault();

            return layout;
        }

        public LayoutDto GetPriceLayout(int Id)
        {
            var layout = (from a in _context.Layout
                        where a.Id == Id && a.IsDeleted == false
                        select new LayoutDto
                        {
                            Id = a.Id,
                            LayoutTitle = a.LayoutTitle,
                            LayoutCapacity = a.LayoutCapacity.Value,
                            LayoutImages = a.LayoutImages
                        }).FirstOrDefault();

            return layout;
        }

        public void Update(LayoutDto layoutDto)
        {
            var Layout = _mapper.Map<Layout>(layoutDto);
            _context.Layout.Update(Layout);
            _context.SaveChanges();
        }
    }
}
