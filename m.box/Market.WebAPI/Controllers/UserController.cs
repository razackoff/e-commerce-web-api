using Market.Application.Users.Queries.GetUserDetails;
using Market.Application.Users.Queries.GetUserList;
using Market.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Application.Users.Commands.CreateUser;
using Market.Application.Users.Commands.UpdateUser;
using Market.Application.Users.Commands.DeleteCommand;
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
        public async Task<ActionResult<UserListVm>> GetAll()
        {
            var query = new GetUserListQuery
            {
                
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("GetUserById/{id}")]
        [Authorize]
        public async Task<ActionResult<UserDetailsVm>> Get(Guid id)
        {
            var query = new GetUserDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("CreateUser")]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto createUserDto)
        {
            var command = mapper.Map<CreateUserCommand>(createUserDto);
            var userId = await Mediator.Send(command);
            return Ok(userId);
        }

        [HttpPut("UpdateUser")]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto updateUserDto)
        {
            var command = mapper.Map<UpdateUserCommand>(updateUserDto);
            command.Id = Id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("DeleteUser/{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
