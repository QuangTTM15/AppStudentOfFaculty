using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudentOfFaculty.Common
{
    public class EnumCommon
    {
        public enum EGender
        {
            Male = 1,
            FeMale = 2,
            LGBT = 3
        }

        public enum ERoleType
        {
            [Description("Administrator")]
            Administrator = 1,
            [Description("Manager")]
            Manager = 2,
            [Description("Coordinator")]
            Coordinator = 3,
            [Description("Student")]
            Student = 4,
            [Description("Guest")]
            Guest = 5
        }
    }
}
