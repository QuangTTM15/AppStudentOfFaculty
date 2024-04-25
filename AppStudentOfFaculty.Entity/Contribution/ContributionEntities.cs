using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudentOfFaculty.Entity.Contribution
{
    [Table("Contribution")]

    public class ContributionEntities : BaseEntities
    {
        public string FileName { get; set; }
        public long UserId { get; set; }
        public int TypeFile { get; set; }
        public bool IsPublished { get; set; }

    }
}
