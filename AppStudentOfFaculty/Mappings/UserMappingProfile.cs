using AppStudentOfFaculty.Dto.User;
using AppStudentOfFaculty.Entity.User;
using AutoMapper;

namespace AppStudentOfFaculty.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserEntities, UserDto>().ReverseMap();
        }
    }
}
