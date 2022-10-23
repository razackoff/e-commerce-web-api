using AutoMapper;
using Market.Application.Common.Mappings;
using Market.Application.Users.Commands.UpdateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Market.Domain.User;

namespace Market.WebAPI.Models
{
    public class UpdateUserDto : IMapWith<UpdateUserCommand>
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
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
                .ForMember(userCommand => userCommand.Id,
                    opt => opt.MapFrom(userDto => userDto.Id))
                .ForMember(userCommand => userCommand.PhoneNumber,
                    opt => opt.MapFrom(userDto => userDto.PhoneNumber))
                .ForMember(userCommand => userCommand.Password,
                    opt => opt.MapFrom(userDto => userDto.Password))
                .ForMember(userCommand => userCommand.FirstName,
                    opt => opt.MapFrom(userDto => userDto.FirstName))
                .ForMember(userCommand => userCommand.SecondName,
                    opt => opt.MapFrom(userDto => userDto.SecondName))
                .ForMember(userCommand => userCommand.DateOfBirth,
                    opt => opt.MapFrom(userDto => userDto.DateOfBirth))
                .ForMember(userCommand => userCommand.Region,
                    opt => opt.MapFrom(userDto => userDto.Region))
                .ForMember(userCommand => userCommand.Locality,
                    opt => opt.MapFrom(userDto => userDto.Locality))
                .ForMember(userCommand => userCommand.Gender,
                    opt => opt.MapFrom(userDto => userDto.Gender))
                .ForMember(userCommand => userCommand.Email,
                    opt => opt.MapFrom(userDto => userDto.Email));
        }
    }
}
