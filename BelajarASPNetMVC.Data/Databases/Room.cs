using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Data.Databases
{
    [Table("Room")]
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public bool Status { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public string FilePath { get; set; }
        public Nullable<int> LayoutId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Layout Layout { get; set; }
    }
}
