using HepsiApi.Application.DTOs;
using HepsiApi.Application.Interfaces.AutoMapper;
using HepsiApi.Application.Interfaces.UnitOfWorks;
using HepsiApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Features.Products.Queries.GetAllProducts
{

    
    //request ve response ı yönettiğimiz yer
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {

            //Brand i productın içine ekliyorum
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include: x=>x.Include(b=>b.Brand)); //bir liste içine atmam gerekiyor dönen değerleri
           
            var brand= mapper.Map<BrandDto,Brand>(new Brand());

            var map = mapper.Map<GetAllProductsQueryResponse,Product>(products);

            foreach (var item in map)
                item.Price -= item.Price * item.Discount / 100;

            return map;
        }
    }
}
