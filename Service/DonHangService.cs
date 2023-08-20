using QL_Nuoc.Models;
using QL_Nuoc.Repository;

namespace QL_Nuoc.Service
{
    public interface IDonHangService
    {
        List<DonHangEntity> getAllDonHang();
        DonHangEntity getDonHangById(string id);
        void createDonHang(DonHangEntity donHang);
        void updateDonHang(DonHangEntity donHang);
        void deleteDonHang(String id);
    }
    public class DonHangService:IDonHangService
    { 
        private readonly IDonHangRepository _donHangRepository;
        public DonHangService(IDonHangRepository donHangRepository)
        {
            _donHangRepository = donHangRepository;
        }
        public List<DonHangEntity> getAllDonHang()
        {
           return _donHangRepository.GetAllDonHang();
        }
        public DonHangEntity getDonHangById(string id)
        {
            return _donHangRepository.GetDonHangById(id);
        }
        public void createDonHang(DonHangEntity donHang)
        {
            _donHangRepository.createDonHang(donHang);
        }
        public void updateDonHang(DonHangEntity donHang)
        {
            _donHangRepository.updateDonHang(donHang);
        }
        public void deleteDonHang(string id) 
        {
            _donHangRepository.deleteDonHang(id);
        }
    }
}
