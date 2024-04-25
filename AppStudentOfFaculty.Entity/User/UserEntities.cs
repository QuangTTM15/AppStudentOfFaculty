using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudentOfFaculty.Entity.User
{

    [Table("User")]
    public class UserEntities : BaseEntities
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public string Avartar { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Gender { get; set; }
        public int Level { get; set; }
        public bool IsSupperAdmin { get; set; }
        public long FacultyId { get; set; }
    }
}
