using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Services.Layouts.Dto
{
    public class LayoutDto
    {
        public int Id { get; set; }
        public string LayoutDescription { get; set; }
        public byte[] LayoutImages { get; set; }
        public string ImageString { get; set; }
        public string LayoutFilePath { get; set; }
        public string LayoutTitle { get; set; }
        public Nullable<int> LayoutPrice { get; set; }
        public Nullable<int> LayoutCapacity { get; set; }
        public bool IsDeleted { get; set; }
    }
}
