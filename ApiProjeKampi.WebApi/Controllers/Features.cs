using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.FeatureDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Features : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public Features(ApiContext context)
        {
            _context = context;
        }

        public Features(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));

        }

        [HttpPost]
        IActionResult CreateFeatureDto(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            _context.Features.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var values = _context.Features.Find(id);
            _context.Features.Remove(values);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);
            _context.Features.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdFeature(int id)
        {
            var values = _mapper.Map<Feature>(_context.Features.Find(id));
            return Ok(_mapper.Map<List<GetByIdFeatureDto>>(values));
        }
    }
}
