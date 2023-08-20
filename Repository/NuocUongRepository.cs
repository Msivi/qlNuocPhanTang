using QL_Nuoc.Models;

namespace QL_Nuoc.Repository
{
    public interface INuocUongRepository
    {
        List<NuocUongEntity> getAllNuocUong();
        NuocUongEntity getNuocUongById(string id);
      
        void createNuocUong(NuocUongEntity nuocUong);
        void updateNuocUong(NuocUongEntity nuocUong);
        void deleteNuocUongById(string id);
    }
    public class NuocUongRepository:INuocUongRepository 
    {
        private readonly AppDbContext _context;
        public NuocUongRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<NuocUongEntity> getAllNuocUong()
        {
            return _context.NuocUongEntities.ToList();


        }
        public NuocUongEntity getNuocUongById(string id)
        {
            var nuocUong = getAllNuocUong().FirstOrDefault(c => c.Id == id);
            return nuocUong;
        }
       
        public void createNuocUong(NuocUongEntity nuocUong)
        {
            try
            {
                _context.NuocUongEntities.Add(nuocUong);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void updateNuocUong(NuocUongEntity nuocUong)
        {
            try
            {
                _context.NuocUongEntities.Update(nuocUong);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void deleteNuocUongById(string id)
        {
            try
            {
                var nuocUong = getAllNuocUong().FirstOrDefault(c => c.Id == id);
                _context.NuocUongEntities.Remove(nuocUong);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
