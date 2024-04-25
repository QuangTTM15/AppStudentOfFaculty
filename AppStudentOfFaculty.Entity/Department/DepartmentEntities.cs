using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudentOfFaculty.Entity.Department
{
    [Table("Department")]
    public class DepartmentEntities : BaseEntities
    {
        public string Name { get; set; }
        public long FacultyId { get; set; }
    }
}
