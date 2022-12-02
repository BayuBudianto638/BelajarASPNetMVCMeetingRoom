using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Services.BookingLists.Dto
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime TranDate { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string BookingCode { get; set; }
        public string ReservedCode { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
        public string SpecialRequest { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> FinishTime { get; set; }
        public Nullable<int> MeetingRoomType { get; set; }
        public Nullable<int> NumberOfPeople { get; set; }
        public Nullable<int> Facilities { get; set; }
        public Nullable<int> LayoutId { get; set; }
        public Nullable<int> PaymentMethod { get; set; }
        public Nullable<decimal> RoomPrice { get; set; }
        public Nullable<decimal> EquipmentPrice { get; set; }
        public Nullable<decimal> FoodAndDrinkPrice { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> Deposit { get; set; }
        public Nullable<int> RoomSlotId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
