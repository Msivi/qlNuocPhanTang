namespace QL_Nuoc.Model
{
    public class DonHangModel
    {
        public string Id { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public string TrangThai { get; set; }

        public string CustumerID { get; set; }
    }
}
