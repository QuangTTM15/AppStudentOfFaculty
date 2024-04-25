using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudentOfFaculty.Entity.Faculty
{
    [Table("Faculty")]
    public class FacultyEntities : BaseEntities
    {
        public string Name { get; set; }
        public long CoordinatorId { get; set; }
    }
}
