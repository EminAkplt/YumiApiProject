using ApiProjeKampi.WebApi.Entities;
using FluentValidation;

namespace ApiProjeKampi.WebApi.ValidationRules
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {

            //Validatör kullanımı verileri filtrelemek daha sağlıklı girdiler için kullanılır.
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş olamaz.");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalıdır.");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olmalıdır.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş olamaz.");
            
        }
    }
}
