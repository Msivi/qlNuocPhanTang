using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Nuoc.Models
{
    [Table("ChiTietDonHang")]
    public class ChiTietDonHangEntity:Entity
    {
        public int MaNuocUong { get; set; }
        public int SoLuong { get; set; }
        public float GiaTien { get; set; }



        [ForeignKey("NuocUong")]
        public string? NuocUongID { get; set; }
        public virtual NuocUongEntity? NuocUong { get; set; }


        [ForeignKey("DonHang")]
        public string? DonHangID { get; set; }
        public virtual DonHangEntity? DonHang { get; set; }
    }
}
