using QL_Nuoc.Models;

namespace QL_Nuoc.Repository
{
    public interface ILoaiNuocUongRepository
    {
        List<LoaiNuocUongEntity> getAllLoaiNuocUong();
        LoaiNuocUongEntity getLoaiNuocUongById(string id);
        void createLoaiNuocUong(LoaiNuocUongEntity loaiNuoc);
        void updateLoaiNuocUong(LoaiNuocUongEntity loaiNuoc);
        void deleteLoaiNuocUongById(string id);
    }
    public class LoaiNuocUongRepository: ILoaiNuocUongRepository
    {
        private readonly AppDbContext _context;
        public LoaiNuocUongRepository( AppDbContext context)
        {
            _context = context;
        }
        public List<LoaiNuocUongEntity> getAllLoaiNuocUong()
        {
            return _context.LoaiNuocUongEntities.ToList();
        }
        public LoaiNuocUongEntity getLoaiNuocUongById( string id)
        {
            var LoaiNuoc = getAllLoaiNuocUong().FirstOrDefault(c => c.Id == id);
            return LoaiNuoc;
        }
        public void createLoaiNuocUong(LoaiNuocUongEntity loaiNuoc)
        {
            try
            {
                _context.LoaiNuocUongEntities.Add(loaiNuoc);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }

        }
        public void updateLoaiNuocUong(LoaiNuocUongEntity loaiNuoc)
        {
            try
            {
                _context.LoaiNuocUongEntities.Update(loaiNuoc);
                _context.SaveChanges();
            }
            catch(Exception e) 
            { 
                throw e; 
            }
        }
       public void deleteLoaiNuocUongById(string id)
        {
            try
            {
                var loaiNuoc = getAllLoaiNuocUong().FirstOrDefault(l => l.Id == id);
                _context.LoaiNuocUongEntities.Remove(loaiNuoc);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
