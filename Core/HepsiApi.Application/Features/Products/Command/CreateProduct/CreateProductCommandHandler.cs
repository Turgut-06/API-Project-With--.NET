using HepsiApi.Application.Bases;
using HepsiApi.Application.Features.Products.Rules;
using HepsiApi.Application.Interfaces.AutoMapper;
using HepsiApi.Application.Interfaces.UnitOfWorks;
using HepsiApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : BaseHandler, IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly ProductRules productRules;

        public CreateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {

            IList<Product> products= await unitOfWork.GetReadRepository<Product>().GetAllAsync();
          
            await productRules.ProductTitleMustNotBeSame(products,request.Title);

            Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);

            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);

            if (await unitOfWork.SaveAsync() > 0) //unitOfWork.SaveAsync int değer döner veri tabanına kaç tane add işlemi yapılmışsa onu döner
            {
                foreach (var categoryId in request.CategoryIds)
                {
                    await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,                        //bu işlem sayesinde hep aynı product ı dönmesine rağmen farklı kategorilere sahip olabiliyor

                        CategoryId = categoryId
                    });
                    await unitOfWork.SaveAsync(); //2 tane saveAsync var yukarıdaki product ın önce oluşması için bize productId lazım
                }


                



            }
            return Unit.Value; // unit boş dönebilmemizi sağlar void gibi çalışır Task a da ekledik
        }
    }
}
