using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_Nuoc.Model;
using QL_Nuoc.Models;
using QL_Nuoc.Service;

namespace QL_Nuoc.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ChiTietDonHangController : ControllerBase
    {
        private readonly IChiTietDonHangService _chiTietDonHangService;
        public ChiTietDonHangController(IChiTietDonHangService chiTietDonHangService)
        {
            _chiTietDonHangService = chiTietDonHangService;
        }
        [HttpGet]
        [Route("/api/[controller]/get-all-ct-don-hang")]
        public IActionResult getAllChiTietDonHang()
        {
            var ctDonHang = _chiTietDonHangService.getAllChiTietDonHang();
            if (!ctDonHang.Any())
            {
                return BadRequest("Không có đơn hàng nào");
            }
            return Ok(ctDonHang);
        }
        [HttpGet]
        [Route("/api[controller]/get-ct-don-hang-id")]
        public IActionResult getChiTietDonHangById(string id)
        {
            var ctDonHang = _chiTietDonHangService.getChiTietDonHangById(id);
            if (ctDonHang is null)
            {
                return BadRequest("Không tìm thấy id đã nhập");
            }
            return Ok(ctDonHang);
        }
        [HttpPost]
        [Route("/api[controller]/create-ct-don-hang")]
        public IActionResult createCTDonHang(ChiTietDonHangModel CTDonHangModel)
        {
            try
            {
                var ktId = _chiTietDonHangService.getAllChiTietDonHang().Where(c => c.Id == CTDonHangModel.Id);
                if(ktId.Any())
                {
                    return BadRequest("Id Don Hang da ton tai!!");
                }
                ChiTietDonHangEntity ct = new ChiTietDonHangEntity
                {
                    Id = CTDonHangModel.Id,
                    DonHangID = CTDonHangModel.DonHangID,
                    MaNuocUong = CTDonHangModel.MaNuocUong,
                    SoLuong = CTDonHangModel.SoLuong,
                    GiaTien = CTDonHangModel.GiaTien,                 
                    NuocUongID=CTDonHangModel.NuocUongID


                };
                _chiTietDonHangService.createChitietDonHang(ct);
                return Ok(ct);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route("api/[controller]/update-ct-don-hang")]
        public IActionResult updateCTDonHang(ChiTietDonHangModel ctDonHang)
        {
            try
            {
                ChiTietDonHangEntity ct = new ChiTietDonHangEntity
                {
                    Id = ctDonHang.Id,
                    MaNuocUong = ctDonHang.MaNuocUong,
                   SoLuong = ctDonHang.SoLuong,
                    GiaTien = ctDonHang.GiaTien,
                    DonHangID = ctDonHang.DonHangID,
                    NuocUongID = ctDonHang.NuocUongID,
                     
                };
                _chiTietDonHangService.updateChiTietDonHang(ct);
                return Ok(ct);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[controller]/delete-ct-don-hang")]
        public IActionResult deleteCTDonHang(string id)
        {
            try
            {
                var ktId=_chiTietDonHangService.getChiTietDonHangById(id);
                if(ktId is null)
                {
                    return BadRequest("Khong tim thay chi tiet don hang de xoa!");
                }
               _chiTietDonHangService.deleteChiTietDonHang(id);
                return Ok("Xoa thanh cong");

            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }


    }
}
