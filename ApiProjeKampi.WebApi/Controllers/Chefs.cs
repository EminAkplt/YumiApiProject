using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Chefs : ControllerBase
    {
        private readonly ApiContext _context;

        public Chefs(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ChefList()
        { 
            var values = _context.Chefs.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        { 
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Başarıyla Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var values = _context.Chefs.Find(id);
            _context.Chefs.Remove(values);
            _context.SaveChanges();
            return Ok("Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {
            var values = _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Başarıyla Güncellendi");

        }
        
    }
}
