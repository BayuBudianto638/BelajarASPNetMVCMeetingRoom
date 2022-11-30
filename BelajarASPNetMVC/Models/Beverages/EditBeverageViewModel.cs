using Mvc.JQuery.DataTables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BelajarASPNetMVC.Models.Beverages
{
    public class EditBeverageViewModel
    {
        public int Id { get; set; }
        [DisplayName("Description")]
        [DataTables(Width = "200px")]
        public string Description { get; set; }
        [DisplayName("Price")]
        [DataTables(Width = "50px")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }
        [DisplayName("Title")]
        [DataTables(Width = "50px")]
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
    }
}
