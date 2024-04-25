using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudentOfFaculty.Dto.User
{
    public class UserInfoDto
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Avatart { get; set; }
        public bool IsSupperAdmin { get; set; }
        public long RoleId { get; set; }
    }
}
