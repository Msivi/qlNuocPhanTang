using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_Nuoc.Model;
using QL_Nuoc.Models;
using QL_Nuoc.Service;

namespace QL_Nuoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NuocUongController : ControllerBase
    {
        private readonly INuocUongService _nuocUongService;
        public NuocUongController(INuocUongService uongService)
        {
            _nuocUongService = uongService;
        }
        [HttpGet]
        [Route("/api/[controller]/get-all-nuoc-uong")]
        public IActionResult getAllNuocUong()
        {
            try
            {
                var nc = _nuocUongService.getAllNuocUong().ToList();
                return Ok(nc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[controller]/get-nuoc-uong-by-id")]
        public IActionResult getNuocUongById(string id)
        {
            try
            {
                var nu = _nuocUongService.getNuocUongById(id);
                if (nu is null)
                {
                    return BadRequest("Khong tim thay nuoc uong");
                }
                return Ok(nu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[controller]/search-nuoc-uong")]
        public IActionResult searchNuocUong(string key)
        {
            try
            {
                
                var search = _nuocUongService.searchNuocUong(key).ToList();
                if(!search.Any())
                {
                    return BadRequest("khong tim thay nuoc uong");
                }
                return Ok(search);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [Route("/api/[controller]/create-nuoc-uong")]
        public IActionResult createNuocUong(NuocUongModel nuocUongModel)
        {
            try
            {
                var ktId = _nuocUongService.getAllNuocUong().Where(c => c.Id == nuocUongModel.Id);
                if (ktId.Any())
                {
                    return BadRequest("Id da ton tai!! Hay nhap id khac.");
                }    
                 
                NuocUongEntity nu = new NuocUongEntity
                {
                    Id = nuocUongModel.Id,
                    TenNuocUong = nuocUongModel.TenNuocUong,
                    GiaTien = nuocUongModel.GiaTien,
                    LoaiNuocUongID = nuocUongModel.LoaiNuocUongID

                };
                _nuocUongService.createNuocUong(nu);
                return Ok(nu);
                
            }
            catch(Exception e) 
            {
                return BadRequest("Them nuoc uong khong thanh cong");
            }
        }
        [HttpPut]
        [Route("/api/[controller]/update-nuoc-uong")]
        public IActionResult updateNuocUong(NuocUongModel nuocUongModel)
        {
            try
            {
                NuocUongEntity nu = new NuocUongEntity
                {
                    Id = nuocUongModel.Id,
                    TenNuocUong = nuocUongModel.TenNuocUong,
                    GiaTien = nuocUongModel.GiaTien,
                    LoaiNuocUongID = nuocUongModel.LoaiNuocUongID
                };
                _nuocUongService.updateNuocUong(nu);
                return Ok(nu);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[controller]/delete-nuoc-uong")]
        public IActionResult deleteNuocUong(string id)
        {
            try
            {
                _nuocUongService.deleteNuocUong(id);
                return Ok("Xoa thanh cong");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
