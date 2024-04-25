using AppStudentOfFaculty.Dto.Faculty;
using AppStudentOfFaculty.Entity.Faculty;
using AppStudentOfFaculty.Entity.User;
using AutoMapper;

namespace AppStudentOfFaculty.Mappings
{
    public class FacultyMappingProfile : Profile
    {
        public FacultyMappingProfile()
        {
            CreateMap<FacultyEntities, FacultyDto>().ReverseMap();
        }
    }
}
