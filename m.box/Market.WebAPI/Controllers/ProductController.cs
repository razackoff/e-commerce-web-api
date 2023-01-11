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
        [Authorize]
        public async Task<ActionResult<ProductListVm>> GetAll()
        {
            var query = new GetProductListQuery
            {
                
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("GetProductById/{id}")]
        [Authorize]
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
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductDto createUserDto)
        {
            var command = mapper.Map<CreateProductCommand>(createUserDto);
            var Id = await Mediator.Send(command);
            Console.WriteLine("Created product:");
            Console.WriteLine("    Id = " + Id.ToString());
            Console.WriteLine("    Id = " + command.UserId.ToString());
            return Ok(Id);
        }

        [HttpPut("UpdateProduct")]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto updateUserDto)
        {
            var command = mapper.Map<UpdateProductCommand>(updateUserDto);
            command.Id = Id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("DeleteProduct/{id}")]
        [Authorize]
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
