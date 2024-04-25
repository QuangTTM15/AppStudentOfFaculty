using AppStudentOfFaculty.Dto.Contribution;
using AppStudentOfFaculty.Entity.Contribution;
using AutoMapper;

namespace AppStudentOfFaculty.Mappings
{
    public class ContributionCommentMappingProfile : Profile
    {
        public ContributionCommentMappingProfile()
        {
            CreateMap<ContributionCommentEntities, ContributionCommentDto>().ReverseMap();
        }
    }
}
