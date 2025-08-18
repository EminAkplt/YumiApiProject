using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Categories : ControllerBase
    {
        private readonly ApiContext _context;

        public Categories(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return Ok(values);

        }

        [HttpGet("GetCategory")]
        public IActionResult CategoryId(int id) 
        { 
            var values = _context.Categories.Find(id);
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateCategory(Category category) 
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Kategori Ekleme işlemi Başarılı");

        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id) 
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category) 
        {
            var values = _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Güncelleme Başarılı");
        }

     
    }
}
