using HepsiApi.Application.Features.Brands.Commands.CreateBrand;
using HepsiApi.Application.Features.Brands.Queries.GetAllBrands;
using HepsiApi.Application.Features.Products.Command.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HepsiApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator mediator;

        public BrandController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var response = await mediator.Send(new GetAllBrandsQueryRequest());

            return Ok(response);

        }
    }
}
