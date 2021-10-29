using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class HoaDon
    {
        public int MaHoaDon { get; set; }
        public int? MaKhachHang { get; set; }
        public decimal? TongTien { get; set; }
        public DateTime? ThoiGian { get; set; }
        public DateTime? CapNhat { get; set; }
        public byte? TinhTrang { get; set; }
    }
}
