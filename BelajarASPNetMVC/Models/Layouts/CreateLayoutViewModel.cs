using Mvc.JQuery.DataTables;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelajarASPNetMVC.Models.Layouts
{
    public class CreateLayoutViewModel
    {
        public int Id { get; set; }
        [DisplayName("Description")]
        [DataTables(Width = "200px")]
        public string LayoutDescription { get; set; }
        [DisplayName("Image Layout")]
        [DataTables(Width = "50px")]
        public byte[] LayoutImages { get; set; }
        [DisplayName("Title")]
        [DataTables(Width = "50px")]
        public string LayoutTitle { get; set; }
        [DisplayName("Price")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public int LayoutPrice { get; set; }
        [DisplayName("Capacity")]
        public int LayoutCapacity { get; set; }
    }
}
