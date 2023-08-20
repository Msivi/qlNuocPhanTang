using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_Nuoc.Model;
using QL_Nuoc.Models;
using QL_Nuoc.Service;

namespace QL_Nuoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiNuocUongController : ControllerBase
    {
        private readonly ILoaiNuocUongService _loaiNuocUongService;
        public LoaiNuocUongController(ILoaiNuocUongService loaiNuocUongService)
        {
            _loaiNuocUongService = loaiNuocUongService;
        }
        [HttpGet]
        [Route("/api/[controller]/get-all-loai-nuoc-uong")]
        public IActionResult getAllLoaiNuocUong() 
        {
            try
            {
                var dh = _loaiNuocUongService.getAllLoaiNuocUong().ToList();
                return Ok(dh);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[controller]/create-loai-nuoc-uong")]
        public IActionResult createLoaiNuocUong(LoaiNuocUongModel loaiNuocUongModel)
        {
            try
            {
                LoaiNuocUongEntity loaiNuocUongEntity = new LoaiNuocUongEntity
                {
                    Id = loaiNuocUongModel.Id,
                    TenLoaiNU = loaiNuocUongModel.TenLoaiNU
                };
                _loaiNuocUongService.createLoaiNuocUong(loaiNuocUongEntity);
                return Ok(loaiNuocUongEntity);
            }
            catch(Exception ex)
            {
                return BadRequest("Tao loai nuoc uong khong thanh cong");
            }
        }
        [HttpGet]
        [Route("/api/[controller]/get-loai-nuoc-uong-by-id")]
        public IActionResult getLoaiNuocUongById(string id)
        {
            try
            {
                var lNuocUong= _loaiNuocUongService.getLoaiNuocUongById(id);
                return Ok(lNuocUong);
            }
            catch (Exception ex)
            {
                return BadRequest("Tim kiem khong thanh cong");
            }
        }
        [HttpPut]
        [Route("/api/[controller]/update-loai-nuoc-uong")]
        public IActionResult updateLoaiNuocUong(LoaiNuocUongModel nuocUongModel)
        {
            try
            {
                LoaiNuocUongEntity nu = new LoaiNuocUongEntity 
                {
                    Id = nuocUongModel.Id,
                    TenLoaiNU = nuocUongModel.TenLoaiNU
                };
                _loaiNuocUongService.updateLoaiNuocUong(nu);
                return Ok(nu);
            }
           catch (Exception e)
            {
                return BadRequest("Cap nhat khong thanh cong");
            }
        }
        [HttpDelete]
        [Route("/api/[controller]/delete-loai-nuoc-uong")]
        public IActionResult deleteLoaiNuocUong(string id)
        {
            try
            {
                 _loaiNuocUongService.deleteLoaiNuocUongById(id);
                return Ok("Xoa thanh cong");
            }
            catch (Exception ex) 
            {
                return BadRequest("Xoa khong thanh cong");
            }
        }
    }
}
