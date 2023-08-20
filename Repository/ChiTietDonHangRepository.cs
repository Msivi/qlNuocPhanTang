using QL_Nuoc.Model;
using QL_Nuoc.Models;

namespace QL_Nuoc.Repository
{
    public interface IChiTietDonHangRepository
    {
        ChiTietDonHangEntity GetChiTietDonHangById(string id);
        List< ChiTietDonHangEntity> GetAllChiTietDonHang();
        void CreateChiTietDonHang(ChiTietDonHangEntity chiTiet);
        void UpdateChiTietDonHang(ChiTietDonHangEntity chiTiet);
        void DeleteChiTietDonHang(string id);


    }
    public class ChiTietDonHangRepository: IChiTietDonHangRepository 
    { 
        private readonly AppDbContext _context;
        public ChiTietDonHangRepository(AppDbContext context)
        {
            _context = context;
        }
        public void CreateChiTietDonHang(ChiTietDonHangEntity chiTiet)
        {
            try
            {
                _context.chiTietDonHangEntities.Add(chiTiet);
                _context.SaveChanges();
            }
            catch (Exception ex) 
            {
                throw ex;
            }

        }
        public void DeleteChiTietDonHang(string id)
        {
            try
            {
                var ChietTietDonHang = _context.chiTietDonHangEntities.FirstOrDefault(c => c.Id==id);
                _context.chiTietDonHangEntities.Remove(ChietTietDonHang);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ChiTietDonHangEntity> GetAllChiTietDonHang()
        {
            return _context.chiTietDonHangEntities.ToList();
        }
        public ChiTietDonHangEntity GetChiTietDonHangById(string id)
        {
            var chitiet= GetAllChiTietDonHang().Where(c=>c.Id==id).FirstOrDefault();
            return chitiet;
        }

        public void UpdateChiTietDonHang(ChiTietDonHangEntity chiTiet)
        {
            try
            {
                _context.chiTietDonHangEntities.Update(chiTiet);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
