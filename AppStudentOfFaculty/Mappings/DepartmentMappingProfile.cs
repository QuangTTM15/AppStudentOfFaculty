using AppStudentOfFaculty.Dto.Department;
using AppStudentOfFaculty.Entity.Department;
using AppStudentOfFaculty.Entity.User;
using AutoMapper;

namespace AppStudentOfFaculty.Mappings
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<DepartmentEntities, DepartmentDto>().ReverseMap();
        }
    }
}
