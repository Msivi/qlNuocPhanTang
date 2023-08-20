using Microsoft.EntityFrameworkCore;
using QL_Nuoc.Models;

namespace QL_Nuoc
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=LeVi\\SQLEXPRESS;database=QLNuoc;uid=sa;pwd=123;TrustServerCertificate=True");
        }
        public DbSet<ChiTietDonHangEntity>chiTietDonHangEntities { get; set; }
        public DbSet<DonHangEntity> donHangEntities   { get; set; }
        public DbSet<KhachHangEntity> KhachHangEntities { get; set; }
        public DbSet<LoaiNuocUongEntity> LoaiNuocUongEntities { get; set; }
        public DbSet<NuocUongEntity> NuocUongEntities { get; set; }
        
        
    }
}
