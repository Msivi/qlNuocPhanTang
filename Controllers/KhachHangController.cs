using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_Nuoc.Model;
using QL_Nuoc.Models;
using QL_Nuoc.Service;

namespace QL_Nuoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangService _khachHangService;
        public KhachHangController(IKhachHangService khachHangService)
        {
            _khachHangService = khachHangService;
        }
        [HttpGet]
        [Route("/api/[controller]/get-all-khach-hang")]
        public IActionResult getAllKhachHang()
        {
            try
            {
                var kh = _khachHangService.GetAllKhachHang().ToList();
                if (!kh.Any())
                {
                    return BadRequest("Không có khách hàng nào!");
                }
                return Ok(kh);
            }
           catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("/api/[controller]/get-khach-hang-by-id")]
        public IActionResult getKhachHangById(string id)
        {
            try
            {
                var kh = _khachHangService.GetKhachHangById(id);
                if (kh is null)
                {
                    return BadRequest("Khong tim thay khach hang");
                }
                return Ok(kh);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }
        [HttpGet]
        [Route("/api/[controller]/search-khach-hang")]
        public IActionResult searchKhachHang(string key)
        {
            try
            {
                var kh = _khachHangService.SearchKhachHang(key).ToList();
                if (!kh.Any())
                {
                    return BadRequest("Khong tim thay khach hang");
                }
                return Ok(kh);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPost]
        [Route("/api/[controller]/create-khach-hang")]
        public IActionResult createKhachHang(KhachHangModel khachHang)
        {
            try
            {
                var ktId = _khachHangService.GetAllKhachHang().Where(c => c.Id == khachHang.Id);
                if (ktId.Any())
                {
                    return BadRequest("Id da ton tai! Hay nhap vao id khac");

                }
                KhachHangEntity khachHangEntity = new KhachHangEntity
                {
                    Id = khachHang.Id,
                    HoTen = khachHang.HoTen,
                    DiaChi = khachHang.DiaChi,
                    SoDienThoai = khachHang.SoDienThoai,
                };
                _khachHangService.createKhachHang(khachHangEntity);
                return Ok(khachHangEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-khach-hang")]
        public IActionResult updateKhachHang(KhachHangModel khachHang)
        {
            try
            {
                 
                KhachHangEntity kh = new KhachHangEntity
                {
                    Id = khachHang.Id,
                    HoTen = khachHang.HoTen,
                    DiaChi = khachHang.DiaChi,
                    SoDienThoai = khachHang.SoDienThoai,
                };
                _khachHangService.updateKhachHang(kh);
                 
                return Ok(kh);
            }
          catch (Exception ex)
            {
                return BadRequest("Cap nhat khong thanh cong");
            }
        }
        [HttpDelete]
        [Route("/api/[controller]/delete-khach-hang")]
        public IActionResult deleteKhachHang(string id)
        {
            try
            {
                bool kh = _khachHangService.deleteKhachHang(id);
                if (!kh)
                {
                    return BadRequest("Khong tim thay khach hang de xoa!");
                }

                return Ok("Xoa thanh cong");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
         
         
    }
}
