using BelajarASPNetMVC.Application.Services.RoomSlots.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Services.RoomSlots
{
    public interface IRoomSlotAppService
    {
        RoomSlotDto GetById(int id);
        IEnumerable<RoomSlotDto> GetAll(int pageIndex = 1, int pageSize = 10);
        IEnumerable<RoomSlotDto> GetFilter(int? month, int? year, int? roomId);
        IEnumerable<RoomSlotDto> GetRoom();
        void Create(RoomSlotDto roomSlot);
        void Update(RoomSlotDto roomSlot);
        void Delete(string month, string year, string day, string roomId);
        void DeleteById(int id);
        bool GenerateRoomSlot(int startMonth, int endMonth, int year, int roomId);
        bool CheckRoomSlot(int year, int month, int day, string startTime, string finishTime);
        RoomSlotDto GetRoomReserved(int year, int month, int day, string startTime, string finishTime);
        void UpdateRoomSlot(int id, string startTime, string endTime);
    }
}
