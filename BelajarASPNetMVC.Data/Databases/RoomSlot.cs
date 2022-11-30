using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Data.Databases
{
    [Table("RoomSlot")]
    public class RoomSlot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int LayoutId { get; set; }
        public int Capacity { get; set; }
        public Nullable<int> Month { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<int> Days { get; set; }
        public Nullable<byte> Hour1 { get; set; }
        public Nullable<byte> Hour2 { get; set; }
        public Nullable<byte> Hour3 { get; set; }
        public Nullable<byte> Hour4 { get; set; }
        public Nullable<byte> Hour5 { get; set; }
        public Nullable<byte> Hour6 { get; set; }
        public Nullable<byte> Hour7 { get; set; }
        public Nullable<byte> Hour8 { get; set; }
        public Nullable<byte> Hour9 { get; set; }
        public Nullable<byte> Hour10 { get; set; }
        public Nullable<byte> Hour11 { get; set; }
        public Nullable<byte> Hour12 { get; set; }
        public Nullable<byte> Hour13 { get; set; }
        public Nullable<byte> IsActive { get; set; }
        public virtual Room Room { get; set; }
        public virtual Layout Layout { get; set; }
    }
}
