using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Data.Databases
{
    [Table("Layout")]
    public class Layout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LayoutDescription { get; set; }
        public byte[] LayoutImages { get; set; }
        public string LayoutFilePath { get; set; }
        public string LayoutTitle { get; set; }
        public Nullable<int> LayoutPrice { get; set; }
        public Nullable<int> LayoutCapacity { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Room> Room { get; set; }
    }
}
