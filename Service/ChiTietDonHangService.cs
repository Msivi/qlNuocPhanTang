using QL_Nuoc.Models;
using QL_Nuoc.Repository;
using System.Xml.Serialization;

namespace QL_Nuoc.Service
{
    public interface IChiTietDonHangService
    {
        List<ChiTietDonHangEntity> getAllChiTietDonHang();
        ChiTietDonHangEntity getChiTietDonHangById(string id);
        //List<ChiTietDonHangEntity> SearchChiTiet(String searchKey);
        void createChitietDonHang(ChiTietDonHangEntity chiTietDon);
        void deleteChiTietDonHang(String id);
        void updateChiTietDonHang(ChiTietDonHangEntity chiTietDon);
    }
    public class ChiTietDonHangService : IChiTietDonHangService
    {
        private readonly IChiTietDonHangRepository _chiTietRepository;
        public ChiTietDonHangService (IChiTietDonHangRepository chiTietRepository)
        {
            _chiTietRepository = chiTietRepository;
        }

        public List<ChiTietDonHangEntity> getAllChiTietDonHang()
        {
            return _chiTietRepository.GetAllChiTietDonHang();
        }
        public ChiTietDonHangEntity getChiTietDonHangById(string id)
        {
            return _chiTietRepository.GetChiTietDonHangById (id);
        }
        public void createChitietDonHang(ChiTietDonHangEntity chiTietDon)
        {
            _chiTietRepository.CreateChiTietDonHang (chiTietDon);
        }
        public void deleteChiTietDonHang(String id)
        {
            _chiTietRepository.DeleteChiTietDonHang(id);
        }
        public void updateChiTietDonHang(ChiTietDonHangEntity chiTietDon)
        {
            _chiTietRepository.UpdateChiTietDonHang(chiTietDon);
        }
    }
}
