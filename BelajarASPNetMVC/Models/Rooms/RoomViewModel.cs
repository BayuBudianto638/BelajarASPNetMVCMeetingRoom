using Mvc.JQuery.DataTables;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelajarASPNetMVC.Models.Rooms
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        [DisplayName("Capacity")]
        [DataTables(Width = "100px")]
        public int Capacity { get; set; }
        [DisplayName("Description")]
        [DataTables(Width = "200px")]
        public string Description { get; set; }
        [DisplayName("Prices")]
        [DataTables(Width = "100px")]
        public float Price { get; set; }
        [DisplayName("Status")]
        [DataTables(Width = "100px")]
        public bool Status { get; set; }
        [DisplayName("Title")]
        [DataTables(Width = "100px")]
        public string Title { get; set; }
        [DisplayName("Room Image")]
        [DataTables(Width = "100px")]
        public byte[] Image { get; set; }
        public bool IsDeleted { get; set; }
        [DisplayName("Layout")]
        [DataTables(Width = "100px")]
        public int LayoutId { get; set; }
        [DisplayName("Book")]
        [DataTables(Width = "100px")]
        public byte BookFor { get; set; }
        [DisplayName("Layout")]
        [DataTables(Width = "100px")]
        public string LayoutName { get; set; }
    }
}
