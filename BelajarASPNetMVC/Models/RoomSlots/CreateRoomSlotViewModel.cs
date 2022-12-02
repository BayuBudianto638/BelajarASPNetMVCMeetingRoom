using Mvc.JQuery.DataTables;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BelajarASPNetMVC.Models.RoomSlots
{
    public class CreateRoomSlotViewModel
    {
        [DataTables(DisplayName = "Start Month", Sortable = false)]
        public int startMonth { get; set; }
        [DataTables(DisplayName = "End Month", Sortable = false)]
        public int endMonth { get; set; }
        [DataTables(DisplayName = "Year Month", Sortable = false)]
        public int year { get; set; }
        [DataTables(DisplayName = "Room", Sortable = false)]
        public int roomId { get; set; }
    }
}
