using AppStudentOfFaculty.Dto.Contribution;
using AppStudentOfFaculty.Entity.Contribution;
using AppStudentOfFaculty.Entity.User;
using AutoMapper;

namespace AppStudentOfFaculty.Mappings
{
    public class ContributionMappingProfile : Profile
    {
        public ContributionMappingProfile()
        {
            CreateMap<ContributionEntities, ContributionDto>().ReverseMap();
        }
    }
}
