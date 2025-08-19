using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.MessageDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper mapper;

        public MessagesController(ApiContext apiContextt, IMapper mapper)
        {
            this._context = apiContextt;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _context.Messages.ToList();
            return Ok(mapper.Map<List<ResultMessageDto>>(values));

        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
           
            _context.Messages.Add(mapper.Map<Message>(createMessageDto));
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");

        }
        [HttpDelete]
        IActionResult DeleteMessage(int id)
        {
            var values = _context.Messages.Find(id);
            _context.Messages.Remove(values);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var value = mapper.Map<Message>(updateMessageDto);
            _context.Messages.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı");
        }

        [HttpGet("{GetMessage}")]
        public IActionResult GetMessage(int id)
        {
            var values = _context.Messages.Find(id);
            return Ok(mapper.Map<GetByIdMessageDto>(values));
        }
    }

    
}
