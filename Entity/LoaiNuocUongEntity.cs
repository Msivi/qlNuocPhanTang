using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Nuoc.Models
{
    [Table("LoaiNuocUong")]
    public class LoaiNuocUongEntity:Entity
    {
        
            public string TenLoaiNU { get; set; }

            public virtual ICollection< NuocUongEntity> NuocUong { get; set; }
        
    }
}
