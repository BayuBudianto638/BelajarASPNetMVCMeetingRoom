using Mvc.JQuery.DataTables;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelajarASPNetMVC.Models.Equipments
{
    public class CreateEquipmentViewModel
    {
        public int Id { get; set; }
        [DisplayName("Description")]
        [DataTables(Width = "200px")]
        public string Description { get; set; }
        [DisplayName("Price")]
        [DataTables(Width = "50px")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public float Price { get; set; }
        [DisplayName("Title")]
        [DataTables(Width = "50px")]
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
    }
}
