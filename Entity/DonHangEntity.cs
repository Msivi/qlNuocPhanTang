using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Nuoc.Models
{
    [Table("DonHang")]
    public class DonHangEntity:Entity
    {
        public DateTime NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public string TrangThai { get; set; }

        public virtual ICollection< ChiTietDonHangEntity> ChiTietDonHang { get; set; }

        [ForeignKey("KhachHang")]
        public string CustumerID { get; set; }
        public virtual KhachHangEntity KhachHang { get; set; }
    }
}
