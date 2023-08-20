using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using QL_Nuoc.Model;
using QL_Nuoc.Models;

namespace QL_Nuoc.Repository
{
    public interface IKhachHangRepository
    {
        List<KhachHangEntity> getAllKhachHang();
        KhachHangEntity getKhachHangById(string id);
        void createKhachHang(KhachHangEntity khachHang);
        void updateKhachHang(KhachHangEntity khachHang);
        bool deleteKhachHangById(String id);

    }
    public class KhachHangRepository:IKhachHangRepository 
    {
        private readonly AppDbContext _context;
        public KhachHangRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<KhachHangEntity> getAllKhachHang()
        {
            var kh = _context.KhachHangEntities.ToList();
 
            return kh;

        }
        public KhachHangEntity getKhachHangById(string id)
        {
            var khachHang= _context.KhachHangEntities.FirstOrDefault(c=>c.Id==id);
            return khachHang;
        }
        public void createKhachHang([FromBody]KhachHangEntity khachHang)
        {
            try
            {
                _context.KhachHangEntities.Add(khachHang);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void updateKhachHang(KhachHangEntity khachHang)
        {
            try
            {
                _context.KhachHangEntities.Update(khachHang);
                 
                _context.SaveChanges();
                 
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
         
        public bool deleteKhachHangById(String id)
        {
            try
            {
                var khachHang=_context.KhachHangEntities.FirstOrDefault(c=>c.Id == id);
                if(khachHang is null)
                {
                    return false;
                }
                _context.KhachHangEntities.Remove(khachHang);
                _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}
