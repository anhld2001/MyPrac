using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prac1.Data;
using Prac1.Model;
using SQLitePCL;

namespace Prac1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly MyDbContext _context;
        public LoaisController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult GetAll()
        {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loai = _context.Loais.FirstOrDefault(lh => lh.MaLoai == id);
            if(loai == null) 
            {
                return NotFound(); ;
            }
            else
            {
                return Ok(loai);
            }
        }
        [HttpPost]
        public IActionResult Create(LoaiModel loaiModel) 
        {
            try
            {
                var loaiHang = new Loai
                {
                    TenLoai = loaiModel.TenLoai
                };
                _context.Add(loaiHang);
                _context.SaveChanges();
                return Ok(loaiHang);
            }
            catch
            {
                return BadRequest();

            }
        }
        [HttpPut("{id}")]
        public IActionResult EditById(int id, LoaiModel loaiModel)
        {
            var loai = _context.Loais.FirstOrDefault(lh => lh.MaLoai == id);
            if (loai == null)
            {
                return NotFound(); ;
            }
            else
            {
                loai.TenLoai = loaiModel.TenLoai;
                _context.SaveChanges(true);
                return Ok(loai);
            }
        }
    }
}
