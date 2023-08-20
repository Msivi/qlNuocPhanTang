using QL_Nuoc.Models;
using QL_Nuoc.Repository;

namespace QL_Nuoc.Service
{
    public interface ILoaiNuocUongService
    {
        List<LoaiNuocUongEntity> getAllLoaiNuocUong();
        LoaiNuocUongEntity getLoaiNuocUongById(string id);
        void createLoaiNuocUong(LoaiNuocUongEntity loaiNuoc);
        void updateLoaiNuocUong(LoaiNuocUongEntity loaiNuoc);
        void deleteLoaiNuocUongById(String id);
    }
    public class LoaiNuocUongService:ILoaiNuocUongService 
    {
        private ILoaiNuocUongRepository _loaiNuocUongRepository;
        public LoaiNuocUongService(ILoaiNuocUongRepository loaiNuocUongRepository)
        {
            _loaiNuocUongRepository = loaiNuocUongRepository;
        }
        public List<LoaiNuocUongEntity> getAllLoaiNuocUong()
        {
            return _loaiNuocUongRepository.getAllLoaiNuocUong();
        }
        public LoaiNuocUongEntity getLoaiNuocUongById(string id)
        {
            return _loaiNuocUongRepository.getLoaiNuocUongById(id);

        }
        public void createLoaiNuocUong(LoaiNuocUongEntity loaiNuoc)
        {
            _loaiNuocUongRepository.createLoaiNuocUong(loaiNuoc);
        }
        public void updateLoaiNuocUong(LoaiNuocUongEntity loaiNuoc)
        {
            _loaiNuocUongRepository.updateLoaiNuocUong(loaiNuoc);
        }
        public void deleteLoaiNuocUongById(String id)
        {
            _loaiNuocUongRepository.deleteLoaiNuocUongById(id);
        }
    }
}
