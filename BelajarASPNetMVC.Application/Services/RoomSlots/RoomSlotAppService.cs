using AutoMapper;
using BelajarASPNetMVC.Application.Services.RoomSlots.Dto;
using BelajarASPNetMVC.Data;
using BelajarASPNetMVC.Data.Databases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Services.RoomSlots
{
    public class RoomSlotAppService : IRoomSlotAppService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public RoomSlotAppService(AppDbContext contex, IMapper mapper)
        {
            _context = contex;
            _mapper = mapper;
        }

        public bool CheckRoomSlot(int Year, int Month, int Day, string startTime, string finishTime)
        {
            bool isExist = false;
            //RoomSlotDto roomSlot = new RoomSlotDto();

            IEnumerable<RoomSlotDto> data;

            string[] strJam = {"09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00",
                                "16:00", "17:00", "18:00", "19:00", "20:00", "21:00"};

            int[] Hour = new int[13];

            var indexA = Array.FindIndex(strJam, row => row.Contains(startTime));
            var indexB = Array.FindIndex(strJam, row => row.Contains(finishTime));

            int HourLoop = 1;
            for (int i = 0; i < 13; i++)
            {
                if ((i >= indexA) && (i <= indexB))
                {
                    Hour[i] = 1;
                    HourLoop = HourLoop + 1;
                }
            }

            for (int i = 0; i < 13; i++)
            {
                int valueX = Hour[i];
                if (valueX == 1)
                {
                    switch (i)
                    {
                        case 0:
                            data = (from roomSlot in _context.RoomSlot
                                    where
                                      roomSlot.Month == Month &&
                                      roomSlot.Year == Year &&
                                      roomSlot.Days == Day &&
                                      roomSlot.Hour1 == 0 &&
                                      roomSlot.IsActive == 1
                                    select new RoomSlotDto
                                    {
                                        Id = roomSlot.Id,
                                        LayoutId = roomSlot.LayoutId,
                                        Capacity = roomSlot.Capacity,
                                        Month = roomSlot.Month,
                                        Year = roomSlot.Year,
                                        Days = roomSlot.Days,
                                        Hour1 = roomSlot.Hour1,
                                        Hour2 = roomSlot.Hour2,
                                        Hour3 = roomSlot.Hour3,
                                        Hour4 = roomSlot.Hour4,
                                        Hour5 = roomSlot.Hour5,
                                        Hour6 = roomSlot.Hour6,
                                        Hour7 = roomSlot.Hour7,
                                        Hour8 = roomSlot.Hour8,
                                        Hour9 = roomSlot.Hour9,
                                        Hour10 = roomSlot.Hour10,
                                        Hour11 = roomSlot.Hour11,
                                        Hour12 = roomSlot.Hour12,
                                        Hour13 = roomSlot.Hour13,
                                        IsActive = roomSlot.IsActive
                                    }).AsEnumerable();

                            if (data.Count() > 0)
                            {
                                isExist = true;
                            }
                            break;
                        case 1:
                            data = (from roomSlot in _context.RoomSlot
                                    where
                                      //(roomSlot.Capacity >= attendees || roomSlot.Capacity <= attendees) &&
                                      roomSlot.Month == Month &&
                                      roomSlot.Year == Year &&
                                      roomSlot.Days == Day &&
                                      roomSlot.Hour2 == 0 &&
                                      roomSlot.IsActive == 1
                                    select new RoomSlotDto
                                    {
                                        Id = roomSlot.Id,
                                        LayoutId = roomSlot.LayoutId,
                                        Capacity = roomSlot.Capacity,
                                        Month = roomSlot.Month,
                                        Year = roomSlot.Year,
                                        Days = roomSlot.Days,
                                        Hour1 = roomSlot.Hour1,
                                        Hour2 = roomSlot.Hour2,
                                        Hour3 = roomSlot.Hour3,
                                        Hour4 = roomSlot.Hour4,
                                        Hour5 = roomSlot.Hour5,
                                        Hour6 = roomSlot.Hour6,
                                        Hour7 = roomSlot.Hour7,
                                        Hour8 = roomSlot.Hour8,
                                        Hour9 = roomSlot.Hour9,
                                        Hour10 = roomSlot.Hour10,
                                        Hour11 = roomSlot.Hour11,
                                        Hour12 = roomSlot.Hour12,
                                        Hour13 = roomSlot.Hour13,
                                        IsActive = roomSlot.IsActive
                                    }).AsEnumerable();

                            if (data.Count() > 0)
                            {
                                isExist = true;
                            }
                            break;
                        case 2:
                            data = (from roomSlot in _context.RoomSlot
                                    where
                                      //(roomSlot.Capacity >= attendees || roomSlot.Capacity <= attendees) &&
                                      roomSlot.Month == Month &&
                                      roomSlot.Year == Year &&
                                      roomSlot.Days == Day &&
                                      roomSlot.Hour3 == 0 &&
                                      roomSlot.IsActive == 1
                                    select new RoomSlotDto
                                    {
                                        Id = roomSlot.Id,
                                        LayoutId = roomSlot.LayoutId,
                                        Capacity = roomSlot.Capacity,
                                        Month = roomSlot.Month,
                                        Year = roomSlot.Year,
                                        Days = roomSlot.Days,
                                        Hour1 = roomSlot.Hour1,
                                        Hour2 = roomSlot.Hour2,
                                        Hour3 = roomSlot.Hour3,
                                        Hour4 = roomSlot.Hour4,
                                        Hour5 = roomSlot.Hour5,
                                        Hour6 = roomSlot.Hour6,
                                        Hour7 = roomSlot.Hour7,
                                        Hour8 = roomSlot.Hour8,
                                        Hour9 = roomSlot.Hour9,
                                        Hour10 = roomSlot.Hour10,
                                        Hour11 = roomSlot.Hour11,
                                        Hour12 = roomSlot.Hour12,
                                        Hour13 = roomSlot.Hour13,
                                        IsActive = roomSlot.IsActive
                                    }).AsEnumerable();

                            if (data.Count() > 0)
                            {
                                isExist = true;
                            }
                            break;
                        case 3:
                            data = (from roomSlot in _context.RoomSlot
                                    where
                                      //(roomSlot.Capacity >= attendees || roomSlot.Capacity <= attendees) &&
                                      roomSlot.Month == Month &&
                                      roomSlot.Year == Year &&
                                      roomSlot.Days == Day &&
                                      roomSlot.Hour4 == 0 &&
                                      roomSlot.IsActive == 1
                                    select new RoomSlotDto
                                    {
                                        Id = roomSlot.Id,
                                        LayoutId = roomSlot.LayoutId,
                                        Capacity = roomSlot.Capacity,
                                        Month = roomSlot.Month,
                                        Year = roomSlot.Year,
                                        Days = roomSlot.Days,
                                        Hour1 = roomSlot.Hour1,
                                        Hour2 = roomSlot.Hour2,
                                        Hour3 = roomSlot.Hour3,
                                        Hour4 = roomSlot.Hour4,
                                        Hour5 = roomSlot.Hour5,
                                        Hour6 = roomSlot.Hour6,
                                        Hour7 = roomSlot.Hour7,
                                        Hour8 = roomSlot.Hour8,
                                        Hour9 = roomSlot.Hour9,
                                        Hour10 = roomSlot.Hour10,
                                        Hour11 = roomSlot.Hour11,
                                        Hour12 = roomSlot.Hour12,
                                        Hour13 = roomSlot.Hour13,
                                        IsActive = roomSlot.IsActive
                                    }).AsEnumerable();

                            if (data.Count() > 0)
                            {
                                isExist = true;
                            }
                            break;
                        case 4:
                            data = (from roomSlot in _context.RoomSlot
                                    where
                                      //(roomSlot.Capacity >= attendees || roomSlot.Capacity <= attendees) &&
                                      roomSlot.Month == Month &&
                                      roomSlot.Year == Year &&
                                      roomSlot.Days == Day &&
                                      roomSlot.Hour5 == 0 &&
                                      roomSlot.IsActive == 1
                                    select new RoomSlotDto
                                    {
                                        Id = roomSlot.Id,
                                        LayoutId = roomSlot.LayoutId,
                                        Capacity = roomSlot.Capacity,
                                        Month = roomSlot.Month,
                                        Year = roomSlot.Year,
                                        Days = roomSlot.Days,
                                        Hour1 = roomSlot.Hour1,
                                        Hour2 = roomSlot.Hour2,
                                        Hour3 = roomSlot.Hour3,
                                        Hour4 = roomSlot.Hour4,
                                        Hour5 = roomSlot.Hour5,
                                        Hour6 = roomSlot.Hour6,
                                        Hour7 = roomSlot.Hour7,
                                        Hour8 = roomSlot.Hour8,
                                        Hour9 = roomSlot.Hour9,
                                        Hour10 = roomSlot.Hour10,
                                        Hour11 = roomSlot.Hour11,
                                        Hour12 = roomSlot.Hour12,
                                        Hour13 = roomSlot.Hour13,
                                        IsActive = roomSlot.IsActive
                                    }).AsEnumerable();

                            if (data.Count() > 0)
                            {
                                isExist = true;
                            }
                            break;
                        case 5:
                            data = (from roomSlot in _context.RoomSlot
                                    where
                                      //(roomSlot.Capacity >= attendees || roomSlot.Capacity <= attendees) &&
                                      roomSlot.Month == Month &&
                                      roomSlot.Year == Year &&
                                      roomSlot.Days == Day &&
                                      roomSlot.Hour6 == 0 &&
                                      roomSlot.IsActive == 1
                                    select new RoomSlotDto
                                    {
                                        Id = roomSlot.Id,
                                        LayoutId = roomSlot.LayoutId,
                                        Capacity = roomSlot.Capacity,
                                        Month = roomSlot.Month,
                                        Year = roomSlot.Year,
                                        Days = roomSlot.Days,
                                        Hour1 = roomSlot.Hour1,
                                        Hour2 = roomSlot.Hour2,
                                        Hour3 = roomSlot.Hour3,
                                        Hour4 = roomSlot.Hour4,
                                        Hour5 = roomSlot.Hour5,
                                        Hour6 = roomSlot.Hour6,
                                        Hour7 = roomSlot.Hour7,
                                        Hour8 = roomSlot.Hour8,
                                        Hour9 = roomSlot.Hour9,
                                        Hour10 = roomSlot.Hour10,
                                        Hour11 = roomSlot.Hour11,
                                        Hour12 = roomSlot.Hour12,
                                        Hour13 = roomSlot.Hour13,
                                        IsActive = roomSlot.IsActive
                                    }).AsEnumerable();

                            if (data.Count() > 0)
                            {
                                isExist = true;
                            }
                            break;
                        case 6:
                            data = (from roomSlot in _context.RoomSlot
                                    where
                                      //(roomSlot.Capacity >= attendees || roomSlot.Capacity <= attendees) &&
                                      roomSlot.Month == Month &&
                                      roomSlot.Year == Year &&
                                      roomSlot.Days == Day &&
                                      roomSlot.Hour7 == 0 &&
                                      roomSlot.IsActive == 1
                                    select new RoomSlotDto
                                    {
                                        Id = roomSlot.Id,
                                        LayoutId = roomSlot.LayoutId,
                                        Capacity = roomSlot.Capacity,
                                        Month = roomSlot.Month,
                                        Year = roomSlot.Year,
                                        Days = roomSlot.Days,
                                        Hour1 = roomSlot.Hour1,
                                        Hour2 = roomSlot.Hour2,
                                        Hour3 = roomSlot.Hour3,
                                        Hour4 = roomSlot.Hour4,
                                        Hour5 = roomSlot.Hour5,
                                        Hour6 = roomSlot.Hour6,
                                        Hour7 = roomSlot.Hour7,
                                        Hour8 = roomSlot.Hour8,
                                        Hour9 = roomSlot.Hour9,
                                        Hour10 = roomSlot.Hour10,
                                        Hour11 = roomSlot.Hour11,
                                        Hour12 = roomSlot.Hour12,
                                        Hour13 = roomSlot.Hour13,
                                        IsActive = roomSlot.IsActive
                                    }).AsEnumerable();

                            if (data.Count() > 0)
                            {
                                isExist = true;
                            }
                            break;
                        case 7:
                            data = (from roomSlot in _context.RoomSlot
                                    where
                                      //(roomSlot.Capacity >= attendees || roomSlot.Capacity <= attendees) &&
                                      roomSlot.Month == Month &&
                                      roomSlot.Year == Year &&
                                      roomSlot.Days == Day &&
                                      roomSlot.Hour8 == 0 &&
                                      roomSlot.IsActive == 1
                                    select new RoomSlotDto
                                    {
                                        Id = roomSlot.Id,
                                        LayoutId = roomSlot.LayoutId,
                                        Capacity = roomSlot.Capacity,
                                        Month = roomSlot.Month,
                                        Year = roomSlot.Year,
                                        Days = roomSlot.Days,
                                        Hour1 = roomSlot.Hour1,
                                        Hour2 = roomSlot.Hour2,
                                        Hour3 = roomSlot.Hour3,
                                        Hour4 = roomSlot.Hour4,
                                        Hour5 = roomSlot.Hour5,
                                        Hour6 = roomSlot.Hour6,
                                        Hour7 = roomSlot.Hour7,
                                        Hour8 = roomSlot.Hour8,
                                        Hour9 = roomSlot.Hour9,
                                        Hour10 = roomSlot.Hour10,
                                        Hour11 = roomSlot.Hour11,
                                        Hour12 = roomSlot.Hour12,
                                        Hour13 = roomSlot.Hour13,
                                        IsActive = roomSlot.IsActive
                                    }).AsEnumerable();

                            if (data.Count() > 0)
                            {
                                isExist = true;
                            }
                            break;
                        case 8:
                            data = (from roomSlot in _context.RoomSlot
                                    where
                                      //(roomSlot.Capacity >= attendees || roomSlot.Capacity <= attendees) &&
                                      roomSlot.Month == Month &&
                                      roomSlot.Year == Year &&
                                      roomSlot.Days == Day &&
                                      roomSlot.Hour9 == 0 &&
                                      roomSlot.IsActive == 1
                                    select new RoomSlotDto
                                    {
                                        Id = roomSlot.Id,
                                        LayoutId = roomSlot.LayoutId,
                                        Capacity = roomSlot.Capacity,
                                        Month = roomSlot.Month,
                                        Year = roomSlot.Year,
                                        Days = roomSlot.Days,
                                        Hour1 = roomSlot.Hour1,
                                        Hour2 = roomSlot.Hour2,
                                        Hour3 = roomSlot.Hour3,
                                        Hour4 = roomSlot.Hour4,
                                        Hour5 = roomSlot.Hour5,
                                        Hour6 = roomSlot.Hour6,
                                        Hour7 = roomSlot.Hour7,
                                        Hour8 = roomSlot.Hour8,
                                        Hour9 = roomSlot.Hour9,
                                        Hour10 = roomSlot.Hour10,
                                        Hour11 = roomSlot.Hour11,
                                        Hour12 = roomSlot.Hour12,
                                        Hour13 = roomSlot.Hour13,
                                        IsActive = roomSlot.IsActive
                                    }).AsEnumerable();

                            if (data.Count() > 0)
                            {
                                isExist = true;
                            }
                            break;
                        case 9:
                            data = (from roomSlot in _context.RoomSlot
                                    where
                                      //(roomSlot.Capacity >= attendees || roomSlot.Capacity <= attendees) &&
                                      roomSlot.Month == Month &&
                                      roomSlot.Year == Year &&
                                      roomSlot.Days == Day &&
                                      roomSlot.Hour10 == 0 &&
                                      roomSlot.IsActive == 1
                                    select new RoomSlotDto
                                    {
                                        Id = roomSlot.Id,
                                        LayoutId = roomSlot.LayoutId,
                                        Capacity = roomSlot.Capacity,
                                        Month = roomSlot.Month,
                                        Year = roomSlot.Year,
                                        Days = roomSlot.Days,
                                        Hour1 = roomSlot.Hour1,
                                        Hour2 = roomSlot.Hour2,
                                        Hour3 = roomSlot.Hour3,
                                        Hour4 = roomSlot.Hour4,
                                        Hour5 = roomSlot.Hour5,
                                        Hour6 = roomSlot.Hour6,
                                        Hour7 = roomSlot.Hour7,
                                        Hour8 = roomSlot.Hour8,
                                        Hour9 = roomSlot.Hour9,
                                        Hour10 = roomSlot.Hour10,
                                        Hour11 = roomSlot.Hour11,
                                        Hour12 = roomSlot.Hour12,
                                        Hour13 = roomSlot.Hour13,
                                        IsActive = roomSlot.IsActive
                                    }).AsEnumerable();

                            if (data.Count() > 0)
                            {
                                isExist = true;
                            }
                            break;
                        case 10:
                            data = (from roomSlot in _context.RoomSlot
                                    where
                                      //(roomSlot.Capacity >= attendees || roomSlot.Capacity <= attendees) &&
                                      roomSlot.Month == Month &&
                                      roomSlot.Year == Year &&
                                      roomSlot.Days == Day &&
                                      roomSlot.Hour11 == 0 &&
                                      roomSlot.IsActive == 1
                                    select new RoomSlotDto
                                    {
                                        Id = roomSlot.Id,
                                        LayoutId = roomSlot.LayoutId,
                                        Capacity = roomSlot.Capacity,
                                        Month = roomSlot.Month,
                                        Year = roomSlot.Year,
                                        Days = roomSlot.Days,
                                        Hour1 = roomSlot.Hour1,
                                        Hour2 = roomSlot.Hour2,
                                        Hour3 = roomSlot.Hour3,
                                        Hour4 = roomSlot.Hour4,
                                        Hour5 = roomSlot.Hour5,
                                        Hour6 = roomSlot.Hour6,
                                        Hour7 = roomSlot.Hour7,
                                        Hour8 = roomSlot.Hour8,
                                        Hour9 = roomSlot.Hour9,
                                        Hour10 = roomSlot.Hour10,
                                        Hour11 = roomSlot.Hour11,
                                        Hour12 = roomSlot.Hour12,
                                        Hour13 = roomSlot.Hour13,
                                        IsActive = roomSlot.IsActive
                                    }).AsEnumerable();

                            if (data.Count() > 0)
                            {
                                isExist = true;
                            }
                            break;
                        case 11:
                            data = (from roomSlot in _context.RoomSlot
                                    where
                                      //(roomSlot.Capacity >= attendees || roomSlot.Capacity <= attendees) &&
                                      roomSlot.Month == Month &&
                                      roomSlot.Year == Year &&
                                      roomSlot.Days == Day &&
                                      roomSlot.Hour12 == 0 &&
                                      roomSlot.IsActive == 1
                                    select new RoomSlotDto
                                    {
                                        Id = roomSlot.Id,
                                        LayoutId = roomSlot.LayoutId,
                                        Capacity = roomSlot.Capacity,
                                        Month = roomSlot.Month,
                                        Year = roomSlot.Year,
                                        Days = roomSlot.Days,
                                        Hour1 = roomSlot.Hour1,
                                        Hour2 = roomSlot.Hour2,
                                        Hour3 = roomSlot.Hour3,
                                        Hour4 = roomSlot.Hour4,
                                        Hour5 = roomSlot.Hour5,
                                        Hour6 = roomSlot.Hour6,
                                        Hour7 = roomSlot.Hour7,
                                        Hour8 = roomSlot.Hour8,
                                        Hour9 = roomSlot.Hour9,
                                        Hour10 = roomSlot.Hour10,
                                        Hour11 = roomSlot.Hour11,
                                        Hour12 = roomSlot.Hour12,
                                        Hour13 = roomSlot.Hour13,
                                        IsActive = roomSlot.IsActive
                                    }).AsEnumerable();

                            if (data.Count() > 0)
                            {
                                isExist = true;
                            }
                            break;
                        case 12:
                            data = (from roomSlot in _context.RoomSlot
                                    where
                                      //(roomSlot.Capacity >= attendees || roomSlot.Capacity <= attendees) &&
                                      roomSlot.Month == Month &&
                                      roomSlot.Year == Year &&
                                      roomSlot.Days == Day &&
                                      roomSlot.Hour13 == 0 &&
                                      roomSlot.IsActive == 1
                                    select new RoomSlotDto
                                    {
                                        Id = roomSlot.Id,
                                        LayoutId = roomSlot.LayoutId,
                                        Capacity = roomSlot.Capacity,
                                        Month = roomSlot.Month,
                                        Year = roomSlot.Year,
                                        Days = roomSlot.Days,
                                        Hour1 = roomSlot.Hour1,
                                        Hour2 = roomSlot.Hour2,
                                        Hour3 = roomSlot.Hour3,
                                        Hour4 = roomSlot.Hour4,
                                        Hour5 = roomSlot.Hour5,
                                        Hour6 = roomSlot.Hour6,
                                        Hour7 = roomSlot.Hour7,
                                        Hour8 = roomSlot.Hour8,
                                        Hour9 = roomSlot.Hour9,
                                        Hour10 = roomSlot.Hour10,
                                        Hour11 = roomSlot.Hour11,
                                        Hour12 = roomSlot.Hour12,
                                        Hour13 = roomSlot.Hour13,
                                        IsActive = roomSlot.IsActive
                                    }).AsEnumerable();

                            if (data.Count() > 0)
                            {
                                isExist = true;
                            }
                            break;
                        default:
                            isExist = false;
                            break;
                    }

                    if (isExist == true)
                    {
                        return isExist;
                    }
                }
            }

            return isExist;
        }

        public void Create(RoomSlotDto roomSlot)
        {
            var newSlot = _mapper.Map<RoomSlot>(roomSlot);

            _context.RoomSlot.Add(newSlot);
            _context.SaveChanges();
        }

        public void Delete(string Month, string Year, string day, string roomId)
        {
            int m = Convert.ToInt32(Month);
            int y = Convert.ToInt32(Year);
            int d = Convert.ToInt32(day);
            int r = Convert.ToInt32(roomId);

            var roomData = (from roomSlot in _context.RoomSlot
                            where
                              roomSlot.Month == m &&
                              roomSlot.Year == y &&
                              roomSlot.Days == d &&
                              roomSlot.RoomId == r
                            select new RoomSlotDto
                            {
                                Id = roomSlot.Id,
                                LayoutId = roomSlot.LayoutId,
                                Capacity = roomSlot.Capacity,
                                Month = roomSlot.Month,
                                Year = roomSlot.Year,
                                Days = roomSlot.Days,
                                Hour1 = roomSlot.Hour1,
                                Hour2 = roomSlot.Hour2,
                                Hour3 = roomSlot.Hour3,
                                Hour4 = roomSlot.Hour4,
                                Hour5 = roomSlot.Hour5,
                                Hour6 = roomSlot.Hour6,
                                Hour7 = roomSlot.Hour7,
                                Hour8 = roomSlot.Hour8,
                                Hour9 = roomSlot.Hour9,
                                Hour10 = roomSlot.Hour10,
                                Hour11 = roomSlot.Hour11,
                                Hour12 = roomSlot.Hour12,
                                Hour13 = roomSlot.Hour13,
                                IsActive = roomSlot.IsActive
                            }).FirstOrDefault();

            var oldRoom = _context.RoomSlot.FirstOrDefault(w => w.Id == roomData.Id);

            oldRoom.IsActive = 0;

            _context.RoomSlot.Attach(oldRoom);
            _context.Entry(oldRoom).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var oldRoom = _context.RoomSlot.FirstOrDefault(w => w.Id == id);
            oldRoom.IsActive = 0;

            _context.RoomSlot.Attach(oldRoom);
            _context.Entry(oldRoom).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool GenerateRoomSlot(int startMonth, int endMonth, int Year, int layoutId)
        {
            bool isSuccess = false;

            RoomSlotDto roomSlot = new RoomSlotDto();
            

            var layout = from a in _context.Layout
                         where a.Id == layoutId
                         select new
                         {
                             a.Id,
                             a.LayoutTitle,
                             a.LayoutCapacity
                         };

            var mstRoom = layout.FirstOrDefault(w => w.Id == layoutId);

            var checkRoomSlot = from a in _context.RoomSlot
                                where
                                                      a.LayoutId == layoutId &&
                                                      a.Month == startMonth &&
                                                      a.Year == Year
                                select new
                                {
                                    a.Id
                                };

            if (checkRoomSlot.Count() > 0)
            {
                return isSuccess = false;
            }

            DateTime StartDate = new DateTime(Year, startMonth, 1);
            DateTime EndDate = new DateTime(Year, endMonth, 1);

            for (DateTime date = StartDate.Date; date < EndDate.Date.AddMonths(1); date += TimeSpan.FromDays(1))
            {
                roomSlot.RoomId = layoutId;
                roomSlot.LayoutId = layoutId;
                roomSlot.Capacity = mstRoom.LayoutCapacity.Value;
                roomSlot.Month = Convert.ToInt32(date.ToString("MM"));
                roomSlot.Year = Year;
                roomSlot.Days = Convert.ToInt32(date.ToString("dd"));
                roomSlot.Hour1 = 0;
                roomSlot.Hour2 = 0;
                roomSlot.Hour3 = 0;
                roomSlot.Hour4 = 0;
                roomSlot.Hour5 = 0;
                roomSlot.Hour6 = 0;
                roomSlot.Hour7 = 0;
                roomSlot.Hour8 = 0;
                roomSlot.Hour9 = 0;
                roomSlot.Hour10 = 0;
                roomSlot.Hour11 = 0;
                roomSlot.Hour12 = 0;
                roomSlot.Hour13 = 0;
                roomSlot.IsActive = 1;

                var newSlot = _mapper.Map<RoomSlot>(roomSlot);
                _context.RoomSlot.Add(newSlot);
                _context.SaveChanges();
            }

            return isSuccess = true;
        }

        public IEnumerable<RoomSlotDto> GetAll(int pageIndex = 1, int pageSize = 10)
        {
            var data = (from a in _context.RoomSlot
                        join b in _context.Room on new { RoomId = a.RoomId } equals new { RoomId = b.Id } into b_join
                        from b in b_join.DefaultIfEmpty()
                        join c in _context.Layout on new { LayoutId = (int)b.LayoutId } equals new { LayoutId = c.Id } into c_join
                        from c in c_join.DefaultIfEmpty()
                        where a.IsActive == 1
                        select new RoomSlotDto
                        {
                            Id = a.Id,
                            RoomId = a.RoomId,
                            LayoutId = a.LayoutId,
                            Capacity = a.Capacity,
                            Month = a.Month,
                            Year = a.Year,
                            Days = a.Days,
                            Hour1 = a.Hour1,
                            Hour2 = a.Hour2,
                            Hour3 = a.Hour3,
                            Hour4 = a.Hour4,
                            Hour5 = a.Hour5,
                            Hour6 = a.Hour6,
                            Hour7 = a.Hour7,
                            Hour8 = a.Hour8,
                            Hour9 = a.Hour9,
                            Hour10 = a.Hour10,
                            Hour11 = a.Hour11,
                            Hour12 = a.Hour12,
                            Hour13 = a.Hour13,
                            IsActive = a.IsActive,
                            LayoutTitle = c.LayoutTitle
                        }).AsEnumerable();

            return data;
        }

        public RoomSlotDto GetById(int id)
        {
            var result = _context.RoomSlot.FirstOrDefault(w => w.Id == id);

            return _mapper.Map<RoomSlotDto>(result);
        }

        public IEnumerable<RoomSlotDto> GetFilter(int? Month, int? Year, int? layoutId)
        {
            var data = (from a in _context.RoomSlot
                        join b in _context.Layout on new { LayoutId = a.LayoutId } equals new { LayoutId = b.Id }
                        where a.Month == Month && a.Year == Year && a.LayoutId == layoutId
                        select new RoomSlotDto
                        {
                            Id = a.Id,
                            RoomId = a.RoomId,
                            LayoutId = a.LayoutId,
                            Capacity = a.Capacity,
                            Month = a.Month,
                            Year = a.Year,
                            Days = a.Days,
                            Hour1 = a.Hour1,
                            Hour2 = a.Hour2,
                            Hour3 = a.Hour3,
                            Hour4 = a.Hour4,
                            Hour5 = a.Hour5,
                            Hour6 = a.Hour6,
                            Hour7 = a.Hour7,
                            Hour8 = a.Hour8,
                            Hour9 = a.Hour9,
                            Hour10 = a.Hour10,
                            Hour11 = a.Hour11,
                            Hour12 = a.Hour12,
                            Hour13 = a.Hour13,
                            IsActive = a.IsActive,
                            RoomTitle = b.LayoutTitle,
                            LayoutTitle = b.LayoutTitle
                        }).AsEnumerable();

            return data;
        }

        public IEnumerable<RoomSlotDto> GetRoom()
        {
            return _context.RoomSlot
                          .OrderBy(x => x.Id)
                          .Select(x => new RoomSlotDto { Id = x.Id })
                          .ToList();
        }

        public RoomSlotDto GetRoomReserved(int Year, int Month, int day, string startTime, string finishTime)
        {
            throw new NotImplementedException();
        }

        public void Update(RoomSlotDto roomSlot)
        {
            var oldRoomSlot = _mapper.Map<RoomSlot>(roomSlot);

            _context.RoomSlot.Attach(oldRoomSlot);
            _context.Entry(oldRoomSlot).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateRoomSlot(int id, string startTime, string endTime)
        {
            var oldRoom = _context.RoomSlot.FirstOrDefault(w => w.Id == id);

            RoomSlotDto roomSlot = new RoomSlotDto();

            string[] strJam = { "{09:00:00}", "{10:00:00}", "{11:00:00}", "{12:00:00}", "{13:00:00}", "{14:00:00}", "{15:00:00}",
                                "{16:00:00}", "{17:00:00}", "{18:00:00}", "{19:00:00}", "{20:00:00}", "{21:00:00}" };
            int[] hour = new int[13];

            var indexA = Array.FindIndex(strJam, row => row.Contains(startTime));
            var indexB = Array.FindIndex(strJam, row => row.Contains(endTime));

            for (int i = 0; i < 13; i++)
            {
                if ((i >= indexA) && (i < indexB))
                {
                    hour[i] = 1;
                }
            }

            for (int i = 0; i < 13; i++)
            {
                int valueX = hour[i];
                if (valueX == 1)
                {
                    switch (i)
                    {
                        case 0:
                            oldRoom.Hour1 = 0;

                            _context.RoomSlot.Attach(oldRoom);
                            _context.Entry(oldRoom).State = EntityState.Modified;
                            _context.SaveChanges();
                            break;
                        case 1:
                            oldRoom.Hour2 = 0;

                            _context.RoomSlot.Attach(oldRoom);
                            _context.Entry(oldRoom).State = EntityState.Modified;
                            _context.SaveChanges();

                            break;
                        case 2:
                            oldRoom.Hour3 = 0;

                            _context.RoomSlot.Attach(oldRoom);
                            _context.Entry(oldRoom).State = EntityState.Modified;
                            _context.SaveChanges();

                            break;
                        case 3:
                            oldRoom.Hour4 = 0;

                            _context.RoomSlot.Attach(oldRoom);
                            _context.Entry(oldRoom).State = EntityState.Modified;
                            _context.SaveChanges();

                            break;
                        case 4:
                            oldRoom.Hour5 = 0;

                            _context.RoomSlot.Attach(oldRoom);
                            _context.Entry(oldRoom).State = EntityState.Modified;
                            _context.SaveChanges();

                            break;
                        case 5:
                            oldRoom.Hour6 = 0;

                            _context.RoomSlot.Attach(oldRoom);
                            _context.Entry(oldRoom).State = EntityState.Modified;
                            _context.SaveChanges();

                            break;
                        case 6:
                            oldRoom.Hour7 = 0;

                            _context.RoomSlot.Attach(oldRoom);
                            _context.Entry(oldRoom).State = EntityState.Modified;
                            _context.SaveChanges();

                            break;
                        case 7:
                            oldRoom.Hour8 = 0;

                            _context.RoomSlot.Attach(oldRoom);
                            _context.Entry(oldRoom).State = EntityState.Modified;
                            _context.SaveChanges();

                            break;
                        case 8:
                            oldRoom.Hour9 = 0;

                            _context.RoomSlot.Attach(oldRoom);
                            _context.Entry(oldRoom).State = EntityState.Modified;
                            _context.SaveChanges();

                            break;
                        case 9:
                            oldRoom.Hour10 = 0;

                            _context.RoomSlot.Attach(oldRoom);
                            _context.Entry(oldRoom).State = EntityState.Modified;
                            _context.SaveChanges();

                            break;
                        case 10:
                            oldRoom.Hour11 = 0;

                            _context.RoomSlot.Attach(oldRoom);
                            _context.Entry(oldRoom).State = EntityState.Modified;
                            _context.SaveChanges();

                            break;
                        case 11:
                            oldRoom.Hour12 = 0;

                            _context.RoomSlot.Attach(oldRoom);
                            _context.Entry(oldRoom).State = EntityState.Modified;
                            _context.SaveChanges();

                            break;
                        case 12:
                            oldRoom.Hour13 = 0;

                            _context.RoomSlot.Attach(oldRoom);
                            _context.Entry(oldRoom).State = EntityState.Modified;
                            _context.SaveChanges();

                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
