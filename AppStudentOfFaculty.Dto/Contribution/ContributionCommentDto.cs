using System.ComponentModel.DataAnnotations;

namespace AppStudentOfFaculty.Dto.Contribution
{
    public class ContributionCommentDto : BaseDto
    {
        [Required(ErrorMessage = "Required")]
        public string Content { get; set; }
        public long ContributionId { get; set; }
    }
}
