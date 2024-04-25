using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudentOfFaculty.Dto.Report
{
    public class ReportDto : BaseDto
    {
        public long StudentId { get; set; }
        public string StudentName { get; set; }
        public string FileName { get; set; }
        public int TotalComment { get; set; }
    }
}
