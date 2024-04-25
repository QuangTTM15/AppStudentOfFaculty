using AppStudentOfFaculty.Dto.User;
using AppStudentOfFaculty.Entity.User;
using AppStudentOfFaculty.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using static AppStudentOfFaculty.Common.EnumCommon;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using AppStudentOfFaculty.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AppStudentOfFaculty.Dto.Department;

namespace AppStudentOfFaculty.Controllers
{
    public class UserController : Controller
    {
        private readonly HungHoangContext _dbContext;
        private readonly IMapper _mapper;
        public UserController(HungHoangContext context, IMapper mapper)
        {
            this._dbContext = context;
            this._mapper = mapper;
        }
        public async Task<ActionResult> Index()
        {
            var model = await (from u in _dbContext.Users
                               join ur in _dbContext.UserRoles on u.Id equals ur.UserId
                               join r in _dbContext.Roles on ur.RoleId equals r.Id
                               join f in _dbContext.Facultys on u.FacultyId equals f.Id
                               where !u.IsDelete
                               select new UserDto()
                               {
                                   Id = u.Id,
                                   FullName = u.FullName,
                                   Email = u.Email,
                                   Phone = u.Phone,
                                   Password = u.Password,
                                   Address = u.Address,
                                   CreatedAt = u.CreatedAt,
                                   CreatedBy = u.CreatedBy,
                                   UpdatedAt = u.UpdatedAt,
                                   UpdatedBy = u.UpdatedBy,
                                   RoleId = ur.RoleId,
                                   RoleName = r.Name,
                                   FacultyId = u.FacultyId,
                                   FacultyName = f.Name
                               }).OrderByDescending(o => o.CreatedAt).ToListAsync();
            return View(model);
        }

        public ActionResult New()
        {
            var model = new UserDto();
            Set_Data_DropdownRole(ref model);
            Set_Data_DropdownFaculty(ref model);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> New(UserDto model)
        {
            if (!ModelState.IsValid)
            {
                Set_Data_DropdownRole(ref model);
                Set_Data_DropdownFaculty(ref model);
                return View(model);
            }
            using var trans = _dbContext.Database.BeginTransaction();
            try
            {
                model.CreatedBy = UserSession.Id;
                var usersEntities = _mapper.Map<UserDto, UserEntities>(model);
                _dbContext.Users.Add(usersEntities);
                var result = await _dbContext.SaveChangesAsync() > 0;
                if (result)
                {
                    var userRoleEntities = new UserRoleEntities()
                    {
                        UserId = usersEntities.Id,
                        RoleId = model.RoleId,
                        CreatedBy = UserSession.Id
                    };
                    _dbContext.UserRoles.Add(userRoleEntities);
                    result = await _dbContext.SaveChangesAsync() > 0;
                    if (!result)
                    {
                        Set_Data_DropdownRole(ref model);
                        Set_Data_DropdownFaculty(ref model);
                        TempData["IntervalServer"] = "Fail";
                    }
                    try
                    {
                        await Common.MailHelper.SendGmailAsync(model.Email, "Your account have just created successfully!", "<div>Thanks for using Gia Chi Task management</div>");
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else
                {
                    Set_Data_DropdownRole(ref model);
                    Set_Data_DropdownFaculty(ref model);
                    TempData["IntervalServer"] = "Fail";
                    await trans.RollbackAsync();
                }
                await trans.CommitAsync();
                TempData["Successful"] = "Successful";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Set_Data_DropdownRole(ref model);
                Set_Data_DropdownFaculty(ref model);
                TempData["IntervalServer"] = "Fail";
                trans.Rollback();
            }
            return View(model);
        }

        public async Task<ActionResult> Edit(long Id)
        {
            var entity = await _dbContext.Users.Where(w => w.Id == Id).FirstOrDefaultAsync();
            var model = _mapper.Map<UserEntities, UserDto>(entity);
            model.ConfirmPassword = model.Password;
            Set_Data_DropdownRole(ref model);
            Set_Data_DropdownFaculty(ref model);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserDto model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                Set_Data_DropdownRole(ref model);
                Set_Data_DropdownFaculty(ref model);
                ModelState.AddModelError("ConfirmPassword", "Confirm password not correctly");
            }
            if (!ModelState.IsValid)
            {
                Set_Data_DropdownRole(ref model);
                Set_Data_DropdownFaculty(ref model);
                return View(model);
            }
            using var trans = _dbContext.Database.BeginTransaction();
            try
            {
                var entity = await _dbContext.Users.Where(w => w.Id == model.Id).FirstOrDefaultAsync();
                if (entity != null)
                {
                    entity.Id = model.Id;
                    entity.FullName = model.FullName;
                    entity.Email = model.Email;
                    entity.Password = model.Password;
                    entity.Phone = model.Phone;
                    entity.Address = model.Address;
                    entity.DateOfBirth = model.DateOfBirth;
                    entity.FacultyId= model.FacultyId;
                    entity.CreatedAt = DateTime.Now;
                    entity.CreatedBy = model.CreatedBy;
                    entity.UpdatedAt = DateTime.Now;
                    entity.UpdatedBy = model.UpdatedBy;
                    entity.UpdatedBy = UserSession.Id;
                }

                var result = await _dbContext.SaveChangesAsync() > 0;
                if (result)
                {
                    var userRoleEntity = await _dbContext.UserRoles.Where(w => w.UserId == model.Id).FirstOrDefaultAsync();
                    if (userRoleEntity != null)
                    {
                        userRoleEntity.RoleId = model.RoleId;
                        userRoleEntity.UpdatedBy = UserSession.Id;
                        result = await _dbContext.SaveChangesAsync() > 0;
                        if (!result)
                        {
                            Set_Data_DropdownRole(ref model);
                            Set_Data_DropdownFaculty(ref model);
                            TempData["IntervalServer"] = "Fail";
                        }
                    }
                }
                else
                {
                    Set_Data_DropdownRole(ref model);
                    Set_Data_DropdownFaculty(ref model);
                    Set_Data_DropdownRole(ref model);
                    TempData["IntervalServer"] = "Fail";
                }
                await trans.CommitAsync();
                TempData["Successful"] = "Successful";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Set_Data_DropdownRole(ref model);
                Set_Data_DropdownFaculty(ref model);
                TempData["IntervalServer"] = "Fail";
                trans.Rollback();
            }

            return View(model);
        }

        public async Task<ActionResult> Destroy(long Id)
        {
            using var trans = _dbContext.Database.BeginTransaction();
            try
            {
                var userRoleEntity = await _dbContext.UserRoles.Where(w => w.UserId == Id).FirstOrDefaultAsync();
                userRoleEntity.CreatedAt = DateTime.Now;
                userRoleEntity.UpdatedAt = DateTime.Now;
                if (userRoleEntity != null)
                {
                    userRoleEntity.IsDelete = true;
                    var result = await _dbContext.SaveChangesAsync() > 0;
                    if (result)
                    {
                        var user = await _dbContext.Users.Where(w => w.Id == Id).FirstOrDefaultAsync();
                        if (user != null)
                        {
                            user.IsDelete = true;
                            user.CreatedAt = DateTime.Now;
                            user.UpdatedAt = DateTime.Now;
                            result = await _dbContext.SaveChangesAsync() > 0;
                            if (!result)
                            {
                                TempData["IntervalServer"] = "Fail";
                            }
                        }
                    }
                    else
                    {
                        TempData["IntervalServer"] = "Fail";
                    }
                }
                await trans.CommitAsync();
                TempData["Successful"] = "Successful";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["IntervalServer"] = "Fail";
                trans.Rollback();
            }
            return RedirectToAction("Index");
        }

        private void Set_Data_DropdownRole(ref UserDto model)
        {
            model.ListRoles = new List<SelectListItem>();
            model.ListRoles.Add(new SelectListItem()
            {
                Value = ((int)ERoleType.Administrator).ToString(),
                Text = "Administrator"
            });
            model.ListRoles.Add(new SelectListItem()
            {
                Value = ((int)ERoleType.Manager).ToString(),
                Text = "Manager"
            });
            model.ListRoles.Add(new SelectListItem()
            {
                Value = ((int)ERoleType.Coordinator).ToString(),
                Text = "Coordinator"
            });
            model.ListRoles.Add(new SelectListItem()
            {
                Value = ((int)ERoleType.Student).ToString(),
                Text = "Student"
            });
            model.ListRoles.Add(new SelectListItem()
            {
                Value = ((int)ERoleType.Guest).ToString(),
                Text = "Guest"
            });
        }
        private void Set_Data_DropdownFaculty(ref UserDto model)
        {
            model.Facultys = new List<SelectListItem>();
            var data = _dbContext.Facultys.Where(w => !w.IsDelete);
            if (data != null)
            {
                model.Facultys = data.Select(s => new SelectListItem()
                {
                    Value = s.Id.ToString(),
                    Text = s.Name,
                }).ToList();
            }
        }

        public IActionResult SignIn()
        {
            return View();

        }

        [HttpPost]
        public ActionResult SignIn(LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var User = _dbContext.Users.Where(z => z.IsActive && z.Email == model.Email && z.Password == model.Password).Select(s =>
            new UserInfoDto()
            {
                FullName = s.FullName,
                Email = s.Email,
                Id = s.Id,
            }).FirstOrDefault();
            if (User != null)
            {
                User.RoleId = _dbContext.UserRoles.FirstOrDefault(f => f.UserId == User.Id).RoleId;
                var session = HttpContext.Session;
                string jsonSave = JsonConvert.SerializeObject(User);
                session.SetString("user_info", jsonSave);
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                TempData["MessagesError"] = "Fail.";
                return View(model);
            }
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn", "User", new { area = "" });
        }
    }
}
