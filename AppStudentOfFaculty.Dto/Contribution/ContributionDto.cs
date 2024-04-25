using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppStudentOfFaculty.Dto.Contribution
{
    public class ContributionDto : BaseDto
    {
        public string FileName { get; set; }
        [Required(ErrorMessage = "Required")]
        public long UserId { get; set; }
        public int TypeFile { get; set; }
        public string FileURL { get; set; }

        public List<ContributionDto> Contributions { get; set; }
        public List<ContributionCommentDto> ContributionComments { get; set; }
        public long StudentId { get; set; }
        public string StudentName { get; set; }
        public bool IsPublished { get; set; }

        public ContributionDto()
        {
            this.Contributions = new List<ContributionDto>();
            this.ContributionComments = new List<ContributionCommentDto>();
        }
    }
}
