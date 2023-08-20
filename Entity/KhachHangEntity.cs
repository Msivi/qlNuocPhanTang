using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Nuoc.Models
{
    [Table("KhachHang")]
    public class KhachHangEntity:Entity
    {
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public virtual ICollection<DonHangEntity> DonHang { get; set; }
    }
}
