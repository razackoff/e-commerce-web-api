using AutoMapper;
using Market.Application.Common.Mappings;
using Market.Domain;

namespace Market.Application.Users.Queries.GetUserList
{
    public class UserLookupDto : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserLookupDto>()
                .ForMember(userDto => userDto.Id,
                    opt => opt.MapFrom(user => user.Id))
                .ForMember(userDto => userDto.FirstName,
                    opt => opt.MapFrom(user => user.FirstName))
                .ForMember(userDto => userDto.SecondName,
                    opt => opt.MapFrom(user => user.SecondName));
        }
    }
}
