using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandValidator :AbstractValidator<CreateProductCommandRequest> //request e göre validate yapıyor
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty() //empty ve null farklıdır null Title ın hiç olmaması demektir validate ederken bunu istemeyiz empty title ın olup içinin boş olması demektir
                .WithName("Başlık");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithName("Açıklama");

            RuleFor(x => x.BrandId)
                .GreaterThan(0) //0 dan büyük olmalıki ürünün markası olsun
                .WithName("Marka");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithName("Fiyat");

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0) //0 a eşit de olabilir
                .WithName("İndirim oranı");

            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .Must(x => x.Any())
                .WithName("Kategoriler");



        }
    }
}
