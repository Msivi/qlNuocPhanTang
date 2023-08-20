using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Nuoc.Models
{
    [Table("NuocUong")]
    public class NuocUongEntity:Entity
    {
        public string TenNuocUong { get; set; }
        public float GiaTien { get; set; }

        [ForeignKey("LoaiNuocUong")]
        public string? LoaiNuocUongID { get; set; }
        public virtual LoaiNuocUongEntity? LoaiNuocUong { get; set; }

        public virtual ICollection< ChiTietDonHangEntity> ChiTietDonHang { get; set; }
    }
}
