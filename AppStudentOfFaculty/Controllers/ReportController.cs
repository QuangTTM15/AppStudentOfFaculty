using AppStudentOfFaculty.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AppStudentOfFaculty.Dto.Report;
using AppStudentOfFaculty.Dto.User;
using AppStudentOfFaculty.Dto.Contribution;

namespace AppStudentOfFaculty.Controllers
{
    public class ReportController : Controller
    {
        private readonly HungHoangContext _dbContext;
        private readonly IMapper _mapper;
        public ReportController(HungHoangContext context, IMapper mapper)
        {
            this._dbContext = context;
            this._mapper = mapper;
        }
        public async Task<ActionResult> Index()
        {
            var models = await (from c in _dbContext.Contributions
                               join u in _dbContext.Users on c.UserId equals u.Id
                               where !c.IsDelete && c.IsPublished == true
                               select new ReportDto()
                               {
                                   Id = c.Id,
                                   FileName = c.FileName,
                                   CreatedAt = c.CreatedAt,
                                   CreatedBy = c.CreatedBy,
                                   UpdatedAt = c.UpdatedAt,
                                   UpdatedBy = c.UpdatedBy,
                                   StudentId = u.Id,
                                   StudentName = u.FullName
                               }).OrderByDescending(o => o.CreatedAt).ToListAsync();

            if (models != null && models.Any())
            {
                foreach (var item in models)
                {
                    var contributionComments = await _dbContext.ContributionComments.Where(w => w.ContributionId == item.Id).ToListAsync();
                    item.TotalComment = contributionComments.Count();
                }
            }
            return View(models);
        }
    }
}
