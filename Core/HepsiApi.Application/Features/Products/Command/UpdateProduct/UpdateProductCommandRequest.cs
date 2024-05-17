using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandRequest :IRequest<Unit>
    {

        public int Id { get; set; } //ürünün id sine göre ürünü bulup update edeceğim
        public string Title { get; set; }
        public string Description { get; set; }

        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public IList<int> CategoryIds { get; set; }
    }
}

