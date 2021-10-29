using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class BinhLuan
    {
        public int MaBl { get; set; }
        public int MaKhachHang { get; set; }
        public int MaSp { get; set; }
        public string NoiDungBinhLuan { get; set; }
        public DateTime? ThoiGian { get; set; }
    }
}
