using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudentOfFaculty.Entity.Contribution
{
    [Table("ContributionComment")]

    public class ContributionCommentEntities : BaseEntities
    {
        public string Content { get; set; }
        public long ContributionId { get; set; }
    }
}
