using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppStudentOfFaculty.Dto.Faculty
{
    public class FacultyDto : BaseDto
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public long CoordinatorId { get; set; }
        public string CoordinatorName { get; set; }
        public List<SelectListItem> Coordinators { get; set; }
        public FacultyDto()
        {
            Coordinators = new List<SelectListItem>();
        }
    }
}
