using AppStudentOfFaculty.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using AppStudentOfFaculty.Dto.Contribution;
using System.Collections.Generic;
using AppStudentOfFaculty.Models;
using System;
using AppStudentOfFaculty.Entity.Contribution;
using System.IO;
using AppStudentOfFaculty.Dto.User;
using System.IO.Compression;

namespace AppStudentOfFaculty.Controllers
{
    public class ContributionController : Controller
    {
        private readonly HungHoangContext _dbContext;
        private readonly IMapper _mapper;
        public ContributionController(HungHoangContext context, IMapper mapper)
        {
            this._dbContext = context;
            this._mapper = mapper;
        }
        public async Task<ActionResult> Index()
        {
            var models = new List<ContributionDto>();
            if (UserSession.Id > 0)
            {
                if (UserSession.RoleId == 2)
                {
                    models = await (from c in _dbContext.Contributions
                                    join u in _dbContext.Users on c.UserId equals u.Id
                                    join ur in _dbContext.UserRoles on u.Id equals ur.UserId
                                    where !u.IsDelete
                                    select new ContributionDto()
                                    {
                                        Id = c.Id,
                                        FileName = c.FileName,
                                        CreatedAt = c.CreatedAt,
                                        CreatedBy = c.CreatedBy,
                                        UpdatedAt = c.UpdatedAt,
                                        UpdatedBy = c.UpdatedBy,
                                        StudentId = u.Id,
                                        StudentName = u.FullName,
                                        IsPublished = c.IsPublished
                                    }).OrderByDescending(o => o.CreatedAt).ToListAsync();
                } else if (UserSession.RoleId == 4)
                {
                    models = await (from c in _dbContext.Contributions
                                    join u in _dbContext.Users on c.UserId equals u.Id
                                    join ur in _dbContext.UserRoles on u.Id equals ur.UserId
                                    where !u.IsDelete && ur.RoleId == 4
                                    select new ContributionDto()
                                    {
                                        Id = c.Id,
                                        FileName = c.FileName,
                                        CreatedAt = c.CreatedAt,
                                        CreatedBy = c.CreatedBy,
                                        UpdatedAt = c.UpdatedAt,
                                        UpdatedBy = c.UpdatedBy,
                                        StudentId = u.Id,
                                        StudentName = u.FullName,
                                        IsPublished = c.IsPublished
                                    }).OrderByDescending(o => o.CreatedAt).ToListAsync();
                }
                else if(UserSession.RoleId == 3)
                {
                    models = await (from c in _dbContext.Contributions
                                    join u in _dbContext.Users on c.UserId equals u.Id
                                    join f in _dbContext.Facultys on u.FacultyId equals f.Id
                                    where !u.IsDelete && f.CoordinatorId == UserSession.Id
                                    select new ContributionDto()
                                    {
                                        Id = c.Id,
                                        FileName = c.FileName,
                                        CreatedAt = c.CreatedAt,
                                        CreatedBy = c.CreatedBy,
                                        UpdatedAt = c.UpdatedAt,
                                        UpdatedBy = c.UpdatedBy,
                                        StudentId = u.Id,
                                        StudentName = u.FullName,
                                        IsPublished = c.IsPublished
                                    }).OrderByDescending(o => o.CreatedAt).ToListAsync();
                }
                if (models != null && models.Any())
                {
                    foreach (var item in models)
                    {
                        item.FileURL = string.Format("/Uploads/Contributions/{0}", item.FileName);
                        item.ContributionComments = await _dbContext.ContributionComments
                            .Where(w => w.ContributionId == item.Id)
                            .Select(s => new ContributionCommentDto()
                            {
                                Id = s.Id,
                                Content = s.Content,
                            }).ToListAsync();
                    }
                }
            }
            return View(models);
        }
        public ActionResult UploadFile(long Id)
        {
            var model = new UploadContributionDto();
            model.StudentId = UserSession.Id;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> UploadFile(UploadContributionDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.FileUpload == null)
            {
                return View(model);
            }
            var _guid = Guid.NewGuid();
            var fileName = model.FileUpload.FileName;
            var fullName = string.Format("{0}-{1}", _guid, fileName);
            using var trans = _dbContext.Database.BeginTransaction();
            try
            {
                var entity = new ContributionEntities();
                entity.FileName = fullName;
                entity.UserId = model.StudentId;
                entity.CreatedBy = UserSession.Id;
                entity.UpdatedBy = UserSession.Id;
                entity.CreatedAt = DateTime.Now;
                _dbContext.Contributions.Add(entity);
                var result = await _dbContext.SaveChangesAsync() > 0;
                if (result)
                {
                    string path = Path.Combine(string.Format("{0}/{1}", "wwwroot/Uploads/Contributions", fullName));
                    if (!Directory.Exists("wwwroot/Uploads/Contributions"))
                    {
                        // Try to create the directory.
                        Directory.CreateDirectory("wwwroot/Uploads/Contributions");
                    }
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await model.FileUpload.CopyToAsync(stream);
                    }
                    //send mmail to coordinator
                    var user = (await _dbContext.Users.FirstOrDefaultAsync(f => f.Id == model.StudentId));
                    var faculty = await _dbContext.Facultys.FirstOrDefaultAsync(f => f.Id == user.FacultyId);
                    var emailCoordinator = _dbContext.Users.FirstOrDefault(f => f.Id == faculty.CoordinatorId).Email;
                    try
                    {
                        await Common.MailHelper.SendGmailAsync(emailCoordinator, "Contribution of student!", "<div>Student " + user.FullName + " just upload file to the system.</div>");
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    await trans.CommitAsync();
                    TempData["Successful"] = "Successful";
                }
                else
                {
                    TempData["IntervalServer"] = "Fail";
                    await trans.RollbackAsync();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["IntervalServer"] = "Fail";
                trans.Rollback();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddComment(ContributionCommentDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using var trans = _dbContext.Database.BeginTransaction();
            try
            {
                var entity = new ContributionCommentEntities();
                entity.ContributionId = model.ContributionId;
                entity.Content = model.Content;
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = UserSession.Id;
                entity.UpdatedBy = UserSession.Id;
                _dbContext.ContributionComments.Add(entity);
                var result = await _dbContext.SaveChangesAsync() > 0;
                if (result)
                {
                    await trans.CommitAsync();
                    TempData["Successful"] = "Successful";
                }
                else
                {
                    TempData["IntervalServer"] = "Fail";
                    await trans.RollbackAsync();
                }
                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                TempData["IntervalServer"] = "Fail";
                trans.Rollback();
            }
            return Json(new { Success = false });
        }
        public async Task<ActionResult> ZipFile(string ids)
        {
            using var trans = _dbContext.Database.BeginTransaction();
            try
            {
                var idArr = ids.Split(',');
                var fileNames = await _dbContext.Contributions
                    .Where(w => idArr.Contains(w.Id.ToString()))
                    .Select(s => s.FileName).ToListAsync();
                string path = Path.Combine("wwwroot/Uploads/Contributions");
                string[] files = Directory.GetFiles(path);
                using (var memoryStream = new MemoryStream())
                {
                    // Create a new zip archive
                    using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        foreach (var file in files)
                        {
                            if (fileNames.Contains(Path.GetFileName(file)))
                            {
                                var fileInfo = new FileInfo(file);
                                // Create a new entry in the zip archive for each file
                                var entry = zipArchive.CreateEntry(fileInfo.Name);
                                // Write the file contents into the entry
                                using (var entryStream = entry.Open())
                                using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                                {
                                    fileStream.CopyTo(entryStream);
                                }
                            }
                        }
                    }
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    // Return the zip file as a byte array
                    return File(memoryStream.ToArray(), "application/zip", $"file-{DateTime.Now.ToString("dd-mm-yyyy")}.zip");
                }
            }
            catch (Exception ex)
            {
                TempData["IntervalServer"] = "Fail";
                trans.Rollback();
            }
            return File(string.Empty, "application/zip", "files.zip");
        }

        [HttpPost]
        public async Task<ActionResult> Published(long id)
        {
            using var trans = _dbContext.Database.BeginTransaction();
            try
            {
                var entity = await _dbContext.Contributions.FirstOrDefaultAsync(f => f.Id == id);
                if (entity != null)
                {
                    entity.IsPublished = !entity.IsPublished;
                }
                var result = await _dbContext.SaveChangesAsync() > 0;
                if (result)
                {
                    await trans.CommitAsync();
                    TempData["Successful"] = "Successful";
                }
                else
                {
                    TempData["IntervalServer"] = "Fail";
                    await trans.RollbackAsync();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["IntervalServer"] = "Fail";
                trans.Rollback();
            }
            return RedirectToAction("Index");
        }
    }
}
