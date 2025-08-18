using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.ContactDtos;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Contacts : ControllerBase
    {
        private readonly ApiContext _context;

        public Contacts(ApiContext context)
        {
            _context = context;
        }
        //Dto kullanarak yeni bir contact ekleme işlemi
        //Sadece manuel maplemeyi öğrenmek için yaptım gerek duyulmadıkça boşa amelelik.


        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateContactDto(CreateContactDto createContactDto)
        {
            var contact = new Contact();
            contact.MapLocation = createContactDto.MapLocation;
            contact.Adress = createContactDto.Adress;
            contact.Phone = createContactDto.Phone;
            contact.Email = createContactDto.Email;
            contact.OpenHours = createContactDto.OpenHours;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult ContactDelete(int id)
        {

            var values = _context.Contacts.Find(id);
            _context.Contacts.Remove(values);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı");

        }

        [HttpGet("{id}")]
        public IActionResult ContactGetById(int id)
        {
            var values = _context.Contacts.Find(id);
            return Ok(values);
        }




        [HttpPut]
        public IActionResult ContactUpdate(Contact contact)
        {
            Contact contact1 = new Contact();
            contact1.MapLocation = contact.MapLocation;
            contact1.Adress = contact.Adress;
            contact1.Phone = contact.Phone;
            contact1.Email = contact.Email;
            contact1.OpenHours = contact.OpenHours;
            contact1.ContactId = contact.ContactId;
            _context.Contacts.Update(contact1);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı");

        }
    }
}
