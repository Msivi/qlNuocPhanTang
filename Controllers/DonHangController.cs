using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using QL_Nuoc.Model;
using QL_Nuoc.Models;
using QL_Nuoc.Service;

namespace QL_Nuoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangController : ControllerBase
    {
        private readonly IDonHangService _donHangService;
        public DonHangController(IDonHangService donHangService)
        {
            _donHangService = donHangService;
        }
        [HttpGet]
        [Route("/api/[controller]/get-all-don-hang")]
        public IActionResult getAllDonHang()
        {
           var dh= _donHangService.getAllDonHang().ToList();
            return Ok(dh); 
        }
        [HttpPost]
        [Route("/api/[controller]/create-don-hang")]
        public IActionResult createDonHang(DonHangModel donHangModel) 
        {
            try
            {
                var ktId = _donHangService.getAllDonHang().Where(c => c.Id == donHangModel.Id);
                if(ktId.Any())
                {
                    return BadRequest("Id don hang da ton tai!!");
                }

                DonHangEntity newdh = new DonHangEntity
                {
                    Id = donHangModel.Id,
                    NgayDat = donHangModel.NgayDat,
                    NgayGiao = donHangModel.NgayGiao,
                    TrangThai = donHangModel.TrangThai,
                    CustumerID = donHangModel.CustumerID,
 
                };
                _donHangService.createDonHang(newdh);
                return Ok(newdh);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

        }
        [HttpGet]
        [Route("/api/[controller]/get-don-hang-by-id")]
        public IActionResult getDonHangById(string id)
        {
            try
            {
                var dh = _donHangService.getDonHangById(id);
                return Ok(dh);
            }
            catch(Exception e)
            {
                return BadRequest("Khong tim thay don hang ");
            }
            
        }
        [HttpPut]
        [Route("/api/[controller]/update-don-hang")]
        public IActionResult updateDonHang(DonHangModel donHangModle)
        {
            try
            {
                DonHangEntity dh = new DonHangEntity {
                    Id = donHangModle.Id,
                    NgayDat = donHangModle.NgayDat,
                    NgayGiao = donHangModle.NgayGiao,
                    TrangThai = donHangModle.TrangThai,
                    CustumerID = donHangModle.CustumerID

                };
                _donHangService.updateDonHang(dh);
                return Ok(dh);
            }
            catch(Exception e)
            {
                return BadRequest("Cap nhat khong thanh cong!");

            }

        }
        [HttpDelete]
        [Route("/api/[controller]/delete-don-hang")]
        public IActionResult deleteDonHang(string id)
        {
            try
            {
                _donHangService.deleteDonHang(id);
                return Ok("Xoa thanh cong don hang");
            }
            catch (Exception e)
            {
                return BadRequest("Xoa khong thanh cong don hang");
            }
        }
    }
}
