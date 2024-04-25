using AppStudentOfFaculty.Common;
using AppStudentOfFaculty.Dto.User;
using Microsoft.AspNetCore.Http;

namespace AppStudentOfFaculty.Models
{
    public static class UserSession
    {
        private static IHttpContextAccessor _accessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _accessor = httpContextAccessor;
        }

        public static HttpContext HttpContext => _accessor.HttpContext;
        private static UserInfoDto usersInfoDto => HttpContext.Session.Get<UserInfoDto>("user_info");

        public static long Id
        {
            get
            {
                if (usersInfoDto == null)
                    return 0;
                else
                    return usersInfoDto.Id;
            }
            set
            {
                HttpContext.Session.SetString("user_info", null);
            }
        }

        public static string FullName
        {
            get
            {
                if (usersInfoDto == null)
                    return "";
                else
                    return usersInfoDto.FullName;
            }
            set
            {
                HttpContext.Session.SetString("user_info", null);
            }
        }

        public static string Email
        {
            get
            {
                if (usersInfoDto == null)
                    return "";
                else
                    return usersInfoDto.Email;
            }
            set
            {
                HttpContext.Session.SetString("user_info", null);
            }
        }
        public static long RoleId
        {
            get
            {
                if (usersInfoDto == null)
                    return 0;
                else
                    return usersInfoDto.RoleId;
            }
            set
            {
                HttpContext.Session.SetString("user_info", null);
            }
        }

    }
}
