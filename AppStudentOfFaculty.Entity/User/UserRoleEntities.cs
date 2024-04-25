using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudentOfFaculty.Entity.User
{
    [Table("UserRole")]
    public class UserRoleEntities : BaseEntities
    {
        public long RoleId { get; set; }
        public long UserId { get; set; }
    }
}
