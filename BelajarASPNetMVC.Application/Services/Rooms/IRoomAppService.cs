using BelajarASPNetMVC.Application.Services.Rooms.Dto;
using BelajarASPNetMVC.Data.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Services.Rooms
{
    public interface IRoomAppService
    {
        Room GetById(int id);
        Room GetByName(string name);
        IEnumerable<RoomDto> GetAll(int pageIndex = 1, int pageSize = 10);
        IEnumerable<RoomDto> GetRoom(int id);
        IEnumerable<RoomDto> GetAllRoom();
        //RoomSlot GetLayoutImageByRoomId(int id);
        void Create(RoomDto roomDto);
        void Update(RoomDto roomDto);
        void Delete(int id);
    }
}
