using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudentOfFaculty.Dto.Contribution
{
    public class UploadContributionDto
    {
        public long ContributionId { get; set; }
        public long StudentId { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile FileUpload { get; set; }
        public byte[] FileByte { get; set; }
    }
}
