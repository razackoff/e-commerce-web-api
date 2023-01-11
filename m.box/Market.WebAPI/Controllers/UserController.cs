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
    public class UserController : BaseController
    {
        private readonly IMapper mapper;

        public UserController(IMapper mapper) => this.mapper = mapper;

        [HttpGet("GetAllUsers")]
        [Authorize]
        public async Task<ActionResult<ProductListVm>> GetAll()
        {
            var query = new GetProductListQuery
            {
                
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("GetUserById/{id}")]
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

        [HttpPost("CreateUser")]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductDto createUserDto)
        {
            var command = mapper.Map<CreateProductCommand>(createUserDto);
            var userId = await Mediator.Send(command);
            return Ok(userId);
        }

        [HttpPut("UpdateUser")]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto updateUserDto)
        {
            var command = mapper.Map<UpdateProductCommand>(updateUserDto);
            command.Id = Id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("DeleteUser/{id}")]
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
