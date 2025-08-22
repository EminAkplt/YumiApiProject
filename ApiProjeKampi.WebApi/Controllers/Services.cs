using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Services : ControllerBase
    {
        private readonly ApiContext _context;

        public Services(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _context.Services.ToList();
            return Ok(values);

        }

        [HttpGet("GetCategory")]
        public IActionResult ServiceId(int id)
        {
            var values = _context.Services.Find(id);
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Kategori Ekleme işlemi Başarılı");

        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var value = _context.Services.Find(id);
            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            var values = _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Güncelleme Başarılı");
        }
    }
}
