using AutoMapper;
using BelajarASPNetMVC.Application.Services.Beverages.Dto;
using BelajarASPNetMVC.Application.Services.Layouts.Dto;
using BelajarASPNetMVC.Application.Services.Rooms.Dto;
using BelajarASPNetMVC.Data;
using BelajarASPNetMVC.Data.Databases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Services.Rooms
{
    public class RoomAppService : IRoomAppService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public RoomAppService(AppDbContext contex, IMapper mapper)
        {
            _context = contex;
            _mapper = mapper;
        }

        public void Create(RoomDto room)
        {
            var newRoom = _mapper.Map<Room>(room);
            newRoom.IsDeleted = false;

            _context.Room.Add(newRoom);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var Layout = _context.Room.AsNoTracking().FirstOrDefault(w => w.Id == id);

            if (Layout != null)
            {
                var deletedData = _mapper.Map<RoomDto>(Layout);
                deletedData.IsDeleted = true;
                Update(deletedData);
            }
        }

        public IEnumerable<RoomDto> GetAll(int pageIndex = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomDto> GetAllRoom()
        {
            return _context.Room
                           .OrderBy(x => x.Id)
                           .Select(x => new RoomDto { 
                               Id = x.Id, 
                               Title = x.Title, 
                               Capacity = x.Capacity, 
                               Description = x.Description, 
                               IsDeleted = x.IsDeleted 
                           })
                           .AsEnumerable();
        }

        public Room GetById(int id)
        {
            return _context.Room.FirstOrDefault(w => w.Id == id);
        }

        public Room GetByName(string name)
        {
            return _context.Room.FirstOrDefault(w => w.Title == name);
        }

        public IEnumerable<RoomDto> GetRoom(int id)
        {
            return _context.Room
                           .OrderBy(x => x.Id)
                           .Select(x => new RoomDto { Id = x.Id, Title = x.Title })
                           .AsEnumerable();
        }

        public void Update(RoomDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            _context.Room.Update(room);
            _context.SaveChanges();
        }
    }
}
