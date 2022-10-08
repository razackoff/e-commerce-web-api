using Market.Application.Common.Mappings;
using static Market.Domain.User;
using Market.Domain;
using AutoMapper;

namespace Market.Application.Users.Queries.GetUserDetails
{
    public class UserDetailsVm : IMapWith<User>
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
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVm>()
                .ForMember(userVm => userVm.Id,
                    opt => opt.MapFrom(user => user.Id))
                .ForMember(userVm => userVm.PhoneNumber,
                    opt => opt.MapFrom(user => user.PhoneNumber))
                .ForMember(userVm => userVm.Password,
                    opt => opt.MapFrom(user => user.Password))
                .ForMember(userVm => userVm.FirstName,
                    opt => opt.MapFrom(user => user.FirstName))
                .ForMember(userVm => userVm.SecondName,
                    opt => opt.MapFrom(user => user.SecondName))
                .ForMember(userVm => userVm.DateOfBirth,
                    opt => opt.MapFrom(user => user.DateOfBirth))
                .ForMember(userVm => userVm.Region,
                    opt => opt.MapFrom(user => user.Region))
                .ForMember(userVm => userVm.Locality,
                    opt => opt.MapFrom(user => user.Locality))
                .ForMember(userVm => userVm.Gender,
                    opt => opt.MapFrom(user => user.Gender))
                .ForMember(userVm => userVm.Email,
                    opt => opt.MapFrom(user => user.Email))
                .ForMember(userVm => userVm.CreationDate,
                    opt => opt.MapFrom(user => user.CreationDate))
                .ForMember(userVm => userVm.EditDate,
                    opt => opt.MapFrom(user => user.EditDate))
        }
    }
}
