using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.ProductDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController1 : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ProductsController1(IValidator<Product> validator, ApiContext context, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok("Ekleme Başarılı");
            }

        }

        [HttpDelete]

        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound("Ürün bulunamadı.");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok("Ürün silindi.");
        }
        [HttpPut]
        public IActionResult PutProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            else
            {
                var existingProduct = _context.Products.Find(product.ProductId);
                if (existingProduct == null)
                {
                    return NotFound("Ürün bulunamadı.");
                }
                existingProduct.ProductName = product.ProductName;
                existingProduct.ProductDescription = product.ProductDescription;
                existingProduct.Price = product.Price;
                existingProduct.ImageUrl = product.ImageUrl;
                _context.SaveChanges();
                return Ok("Ürün güncellendi.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound("Ürün bulunamadı.");
            }
            return Ok(product);

        }


        [HttpPost("CreateProductWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            _context.Products.Add(values);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");

        }

        [HttpGet ("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var value = _context.Products.Include(x => x.Category).ToList();
            return Ok(_mapper.Map<List<ResultProductWithCategory>>(value));
        }


    }
}

