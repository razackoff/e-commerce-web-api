using System;
using MediatR;
using static Market.Domain.User;

namespace Market.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Region { get; set; }
        public string Locality { get; set; }
        public gender Gender { get; set; }
        public string Email { get; set; }
    }
}
