using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppStudentOfFaculty.Dto.User
{
    public class UserDto : BaseDto
    {
        [Required(ErrorMessage = "Required")]
        [MinLength(6, ErrorMessage = "Password more 6 characters")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail not format.")]
        public string Email { get; set; }
        [RegularExpression("([0-9]+)", ErrorMessage = "Phone not format")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Required")]
        public int Gender { get; set; }
        public string Avartar { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile PictureUpload { get; set; }
        public byte[] PictureByte { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public long FacultyId { get; set; }
        public string FacultyName { get; set; }
        public List<SelectListItem> ListRoles { get; set; }
        public List<SelectListItem> Facultys { get; set; }
        public UserDto()
        {
            this.ListRoles = new List<SelectListItem>();
            Facultys = new List<SelectListItem>();
        }
    }
}
