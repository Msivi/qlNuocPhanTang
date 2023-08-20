using QL_Nuoc.Models;
using QL_Nuoc.Repository;

namespace QL_Nuoc.Service
{
    public interface INuocUongService
    {
        List<NuocUongEntity> getAllNuocUong();
        NuocUongEntity getNuocUongById(string id);
        List<NuocUongEntity>searchNuocUong(string key);
        void createNuocUong(NuocUongEntity nuocUong);
        void updateNuocUong(NuocUongEntity nuocUong);
        void deleteNuocUong(string id);
    }
    public class NuocUongService: INuocUongService
    {
        private readonly INuocUongRepository _nuocUongRepository;
        public NuocUongService(INuocUongRepository nuocUongRepository) 
        {
            _nuocUongRepository= nuocUongRepository;
        }
        public List<NuocUongEntity> getAllNuocUong()
        {
            return _nuocUongRepository.getAllNuocUong().ToList();
        }
        public NuocUongEntity getNuocUongById(string id)
        {
            var nuocUong=_nuocUongRepository.getNuocUongById(id);
            return nuocUong;
        }
        public List<NuocUongEntity> searchNuocUong(string key)
        {
            return _nuocUongRepository.getAllNuocUong()
                .Where(c => 
                       c.TenNuocUong.IndexOf(key,StringComparison.OrdinalIgnoreCase)>=0||  
                       c.GiaTien.ToString().IndexOf(key,StringComparison.OrdinalIgnoreCase)>=0
            
                ).ToList();
           
        }
        public void createNuocUong(NuocUongEntity nuocUong)
        {
            _nuocUongRepository.createNuocUong(nuocUong);
             
        }
        public void updateNuocUong(NuocUongEntity nuocUong)
        {
            _nuocUongRepository.updateNuocUong(nuocUong);
        }
        public void deleteNuocUong(string id)
        {
            _nuocUongRepository.deleteNuocUongById( id );
        }
    }

}
