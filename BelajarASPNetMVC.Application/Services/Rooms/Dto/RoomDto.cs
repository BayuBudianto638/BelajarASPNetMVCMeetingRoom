using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Services.Rooms.Dto
{
    public class RoomDto
    {
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
    }
}
