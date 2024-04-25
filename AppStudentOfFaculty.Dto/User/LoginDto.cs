using System.ComponentModel.DataAnnotations;

namespace AppStudentOfFaculty.Dto.User
{
    public class LoginDto
    {
        [Required(ErrorMessage = "The field is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
