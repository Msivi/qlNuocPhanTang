using QL_Nuoc.Models;

namespace QL_Nuoc.Repository
{
    public interface IDonHangRepository
    {
        DonHangEntity GetDonHangById(string id);
        List<DonHangEntity> GetAllDonHang();
        void createDonHang(DonHangEntity donHang);
        void updateDonHang(DonHangEntity donHang);
        void deleteDonHang(string id);
    }
    public class DonHangRepository:IDonHangRepository 
    {
        private readonly AppDbContext _context;
        public DonHangRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<DonHangEntity> GetAllDonHang()
        {
            return _context.donHangEntities.ToList();
        }
        public DonHangEntity GetDonHangById(string id)
        {
            var donHang= GetAllDonHang().FirstOrDefault(c=>c.Id==id);
            return donHang;
        }
        public void createDonHang(DonHangEntity donHang)
        {
            try
            {
                _context.donHangEntities.Add(donHang);
                _context.SaveChanges();
            }
           catch (Exception ex)
            {
                throw ex;
            }

        }
        public void updateDonHang(DonHangEntity donHang)
        {
            try
            {
                _context.donHangEntities.Update(donHang);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void deleteDonHang(string id)
        {
            try
            {
                var donHang= _context.donHangEntities.FirstOrDefault(c=>c.Id==id);
                _context.donHangEntities.Remove(donHang);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
