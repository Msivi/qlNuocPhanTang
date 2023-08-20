using Microsoft.AspNetCore.Mvc;
using QL_Nuoc.Model;
using QL_Nuoc.Models;
using QL_Nuoc.Repository;

namespace QL_Nuoc.Service
{
    public interface IKhachHangService
    {
        List<KhachHangEntity> GetAllKhachHang();
        KhachHangEntity GetKhachHangById(string id);
        List<KhachHangEntity> SearchKhachHang(string searchKey);
        void createKhachHang(KhachHangEntity khachHang);
        bool deleteKhachHang(string id);
        void updateKhachHang( KhachHangEntity khachHang);
       
    }
    public class KhachHangService:IKhachHangService 
    {
        private readonly IKhachHangRepository _khachHangRepository;
        public KhachHangService(IKhachHangRepository khachHangRepository)
        {
            _khachHangRepository = khachHangRepository;
        }
        
        public List<KhachHangEntity> GetAllKhachHang()
        {
            return _khachHangRepository.getAllKhachHang().ToList();
        }
        public KhachHangEntity GetKhachHangById(string id)
        {
            return _khachHangRepository.getKhachHangById(id);
        }
        public List<KhachHangEntity> SearchKhachHang(string searchKey)
        {
            
            return _khachHangRepository.getAllKhachHang()
        .Where(c =>
            c.HoTen.IndexOf(searchKey, StringComparison.OrdinalIgnoreCase) >= 0 ||
            c.SoDienThoai.IndexOf(searchKey, StringComparison.OrdinalIgnoreCase) >= 0 ||
            c.DiaChi.IndexOf(searchKey, StringComparison.OrdinalIgnoreCase) >= 0)
        .ToList();
        }
        public void createKhachHang([FromBody] KhachHangEntity khachHang)
        {
            _khachHangRepository.createKhachHang(khachHang);
        }
        public bool deleteKhachHang(string id)
        {
            bool kh= _khachHangRepository.deleteKhachHangById(id);
            if(!kh)
            {
                return false;
            }
            return true;
        }
        public void updateKhachHang(KhachHangEntity khachHang)
        {
           _khachHangRepository.updateKhachHang(khachHang);
             
        }
    }
}
