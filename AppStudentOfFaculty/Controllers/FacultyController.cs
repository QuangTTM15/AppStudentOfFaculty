using AppStudentOfFaculty.Common;
using AppStudentOfFaculty.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using AppStudentOfFaculty.Entity;
using System.Linq;
using AppStudentOfFaculty.Dto.Faculty;
using Microsoft.EntityFrameworkCore;
using AppStudentOfFaculty.Entity.Faculty;
using AppStudentOfFaculty.Dto.Department;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AppStudentOfFaculty.Controllers
{
    public class FacultyController : Controller
    {
        private readonly HungHoangContext _dbContext;
        private readonly IMapper _mapper;
        public FacultyController(HungHoangContext context, IMapper mapper)
        {
            this._dbContext = context;
            this._mapper = mapper;
        }
        public async Task<ActionResult> Index()
        {
            var model = await (from f in _dbContext.Facultys
                              join u in _dbContext.Users on f.CoordinatorId equals u.Id
                              where f.IsDelete == false
                              select new FacultyDto()
                              {
                                  Id = f.Id,
                                  Name = f.Name,
                                  CreatedAt = f.CreatedAt,
                                  CreatedBy = f.CreatedBy,
                                  UpdatedAt = f.UpdatedAt,
                                  UpdatedBy = f.UpdatedBy,
                                  CoordinatorName = u.FullName
                              }).ToListAsync();
            return View(model);
        }

        public ActionResult New()
        {
            var model = new FacultyDto();
            Set_Data_DropdownCoordinator(ref model);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> New(FacultyDto model)
        {
            if (!ModelState.IsValid)
            {
                Set_Data_DropdownCoordinator(ref model);
                return View(model);
            }
            using var trans = _dbContext.Database.BeginTransaction();
            try
            {
                model.UpdatedBy = UserSession.Id;
                var entities = _mapper.Map<FacultyDto, FacultyEntities>(model);
                _dbContext.Facultys.Add(entities);
                var result = await _dbContext.SaveChangesAsync() > 0;
                if (result)
                {
                    await trans.CommitAsync();
                    TempData["Successful"] = "Successful";
                }
                else
                {
                    Set_Data_DropdownCoordinator(ref model);
                    TempData["IntervalServer"] = "Fail";
                    await trans.RollbackAsync();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Set_Data_DropdownCoordinator(ref model);
                TempData["IntervalServer"] = "Fail";
                trans.Rollback();
            }
            return View(model);
        }

        public async Task<ActionResult> Edit(long Id)
        {
            var entity = await _dbContext.Facultys.Where(w => w.Id == Id).FirstOrDefaultAsync();
            var model = _mapper.Map<FacultyEntities, FacultyDto>(entity);
            Set_Data_DropdownCoordinator(ref model);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(FacultyDto model)
        {
            if (!ModelState.IsValid)
            {
                Set_Data_DropdownCoordinator(ref model);
                return View(model);
            }
            using var trans = _dbContext.Database.BeginTransaction();
            try
            {
                var entity = await _dbContext.Facultys.Where(w => w.Id == model.Id).FirstOrDefaultAsync();
                if (entity != null)
                {
                    entity.Id = model.Id;
                    entity.Name = model.Name;
                    entity.CoordinatorId = model.CoordinatorId;
                    entity.CreatedAt = DateTime.Now;
                    entity.CreatedBy = model.CreatedBy;
                    entity.UpdatedAt = DateTime.Now;
                    entity.UpdatedBy = model.UpdatedBy;
                    entity.UpdatedBy = UserSession.Id;
                }

                var result = await _dbContext.SaveChangesAsync() > 0;
                if (result)
                {
                    await trans.CommitAsync();
                    TempData["Successful"] = "Successful";
                }
                else
                {
                    Set_Data_DropdownCoordinator(ref model);
                    TempData["IntervalServer"] = "Fail";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Set_Data_DropdownCoordinator(ref model);
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
                var entity = await _dbContext.Facultys.Where(w => w.Id == Id).FirstOrDefaultAsync();
                if (entity != null)
                {
                    entity.IsDelete = true;
                    entity.CreatedAt = DateTime.Now;
                    entity.UpdatedAt = DateTime.Now;
                    var result = await _dbContext.SaveChangesAsync() > 0;
                    if (!result)
                    {
                        TempData["IntervalServer"] = "Fail";
                    }
                }
                else
                {
                    TempData["IntervalServer"] = "Fail";
                }
                await trans.CommitAsync();
                TempData["Successful"] = "Successful";
            }
            catch (Exception ex)
            {
                TempData["IntervalServer"] = "Fail";
                trans.Rollback();
            }
            return RedirectToAction("Index");
        }
        private void Set_Data_DropdownCoordinator(ref FacultyDto model)
        {
            model.Coordinators = new List<SelectListItem>();
            var data = (from u in _dbContext.Users
                        join ur in _dbContext.UserRoles on u.Id equals ur.UserId
                        join r in _dbContext.Roles on ur.RoleId equals r.Id
                        where u.IsDelete == false && r.Name == "Coordinator"
                        select new
                        {
                            Id = u.Id,
                            Name = u.FullName,
                        }).ToList();
            if (data != null)
            {
                model.Coordinators = data.Select(s => new SelectListItem()
                {
                    Value = s.Id.ToString(),
                    Text = s.Name,
                }).ToList();
            }
        }
    }
}
