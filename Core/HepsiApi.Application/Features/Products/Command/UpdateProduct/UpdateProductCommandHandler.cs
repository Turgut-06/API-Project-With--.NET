using HepsiApi.Application.Bases;
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

namespace HepsiApi.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : BaseHandler, IRequestHandler<UpdateProductCommandRequest,Unit>
    {

        public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            
        }
        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.isDeleted);

            var map = mapper.Map<Product, UpdateProductCommandRequest>(request);

            var productCategories= await unitOfWork.GetReadRepository<ProductCategory>()
                .GetAllAsync(x=> x.ProductId ==product.Id);   //çoka çok tablo olduğu için product a ait bütün categoryId leri de getirmiş oluyorum

            //product için hangi kategorileri tikleyip seçeceğini bilmediğimizden önce harddelete ile tablodaki bütün bağlantıları silmemiz lazım

            await unitOfWork.GetWriteRepository<ProductCategory>()
                .HardDeleteRangeAsync(productCategories);

            foreach (var categoryId in request.CategoryIds)
            {
                await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()  //tekrardan çoka çok bağlantıyı kuruyoruz client neleri tiklediyse onlar gelir
                {
                    ProductId=product.Id,
                    CategoryId=categoryId
                });
            }
            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(map);
            await unitOfWork.SaveAsync(); //öncesinde product zaten yukarıda bulunup hafızada olduğu için en son 1 tane save yapıyoruz

            return Unit.Value;

        }
    }
}
