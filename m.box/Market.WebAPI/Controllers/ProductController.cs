using Market.Application.Products.Queries.GetProductDetails;
using Market.Application.Products.Queries.GetProductList;
using Market.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Application.Products.Commands.CreateProduct;
using Market.Application.Products.Commands.UpdateProduct;
using Market.Application.Products.Commands.DeleteProduct;
using Microsoft.AspNetCore.Authorization;

namespace Market.WebAPI.Controllers
{

    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IMapper mapper;

        public ProductController(IMapper mapper) => this.mapper = mapper;

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<ProductListVm>> GetAll()
        {
            var query = new GetProductListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<ActionResult<ProductDetailsVm>> Get(Guid id)
        {
            var query = new GetProductDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductDto createUserDto)
        {
            var command = mapper.Map<CreateProductCommand>(createUserDto);
            var Id = await Mediator.Send(command);
            return Ok(Id);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto updateProductDto)
        {
            var command = mapper.Map<UpdateProductCommand>(updateProductDto);
            command.Id = updateProductDto.Id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
