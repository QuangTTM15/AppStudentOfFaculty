using AppStudentOfFaculty.Dto.Faculty;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppStudentOfFaculty.Dto.Department
{
    public class DepartmentDto : BaseDto
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public long FacultyId { get; set; }
        public string FacultyName { get; set; }
        public List<SelectListItem> Facultys { get; set; }
        public DepartmentDto()
        {
            Facultys = new List<SelectListItem>();
        }
    }
}
