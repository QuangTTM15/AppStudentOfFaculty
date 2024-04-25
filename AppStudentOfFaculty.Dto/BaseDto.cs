using System;

namespace AppStudentOfFaculty.Dto
{
    public class BaseDto
    {
        public long Id { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public BaseDto()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            this.IsActive = true;
        }
    }
}
