using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudentOfFaculty.Entity.User
{
    [Table("Role")]
    public class RoleEntities : BaseEntities
    {
        public string Name { set; get; }
    }
}
