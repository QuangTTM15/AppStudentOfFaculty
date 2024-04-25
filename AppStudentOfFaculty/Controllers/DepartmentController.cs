﻿using AppStudentOfFaculty.Dto.Faculty;
using AppStudentOfFaculty.Entity.Faculty;
using AppStudentOfFaculty.Entity;
using AppStudentOfFaculty.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AppStudentOfFaculty.Dto.Department;
using AppStudentOfFaculty.Entity.Department;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AppStudentOfFaculty.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly HungHoangContext _dbContext;
        private readonly IMapper _mapper;
        public DepartmentController(HungHoangContext context, IMapper mapper)
        {
            this._dbContext = context;
            this._mapper = mapper;
        }
        public async Task<ActionResult> Index()
        {
            var model = await (from d in _dbContext.Departments
                               join f in _dbContext.Facultys on d.FacultyId equals f.Id
                               where d.IsDelete == false
                               select new DepartmentDto()
                               {
                                   Id = d.Id,
                                   Name = d.Name,
                                   FacultyName = f.Name,
                                   CreatedAt = d.CreatedAt,
                                   CreatedBy = d.CreatedBy,
                                   UpdatedAt = d.UpdatedAt,
                                   UpdatedBy = d.UpdatedBy
                               }).ToListAsync();
            return View(model);
        }

        public ActionResult New()
        {
            var model = new DepartmentDto();
            Set_Data_DropdownFaculty(ref model);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> New(DepartmentDto model)
        {
            if (!ModelState.IsValid)
            {
                Set_Data_DropdownFaculty(ref model);
                return View(model);
            }
            using var trans = _dbContext.Database.BeginTransaction();
            try
            {
                model.UpdatedBy = UserSession.Id;
                var entities = _mapper.Map<DepartmentDto, DepartmentEntities>(model);
                _dbContext.Departments.Add(entities);
                var result = await _dbContext.SaveChangesAsync() > 0;
                if (result)
                {
                    await trans.CommitAsync();
                    TempData["Successful"] = "Successful";
                }
                else
                {
                    Set_Data_DropdownFaculty(ref model);
                    TempData["IntervalServer"] = "Fail";
                    await trans.RollbackAsync();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Set_Data_DropdownFaculty(ref model);
                TempData["IntervalServer"] = "Fail";
                trans.Rollback();
            }
            return View(model);
        }

        public async Task<ActionResult> Edit(long Id)
        {
            var entity = await _dbContext.Departments.Where(w => w.Id == Id).FirstOrDefaultAsync();
            var model = _mapper.Map<DepartmentEntities, DepartmentDto>(entity);
            Set_Data_DropdownFaculty(ref model);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(DepartmentDto model)
        {
            if (!ModelState.IsValid)
            {
                Set_Data_DropdownFaculty(ref model);
                return View(model);
            }
            using var trans = _dbContext.Database.BeginTransaction();
            try
            {
                var entity = await _dbContext.Departments.Where(w => w.Id == model.Id).FirstOrDefaultAsync();
                if (entity != null)
                {
                    entity.Id = model.Id;
                    entity.Name = model.Name;
                    entity.FacultyId = model.FacultyId;
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
                    Set_Data_DropdownFaculty(ref model);
                    TempData["IntervalServer"] = "Fail";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
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
                var entity = await _dbContext.Departments.Where(w => w.Id == Id).FirstOrDefaultAsync();
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

        private void Set_Data_DropdownFaculty(ref DepartmentDto model)
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
    }
}
