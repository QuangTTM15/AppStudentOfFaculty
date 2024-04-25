using AppStudentOfFaculty.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppStudentOfFaculty.Entity.Faculty;
using AppStudentOfFaculty.Entity.Department;
using AppStudentOfFaculty.Entity.Contribution;

namespace AppStudentOfFaculty.Entity
{
    public class HungHoangContext : DbContext
    {
        public HungHoangContext(DbContextOptions<HungHoangContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                                    .Where(t => t.GetInterfaces()
                                    .Any(gi => gi.IsGenericType
                                    && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
            //seed data
            modelBuilder.Entity<UserEntities>()
                .HasData(
                   new UserEntities
                   {
                       CreatedAt = DateTime.Now,
                       Email = "admin@gmail.com",
                       FullName = "admin@gmail.com",
                       Id = 1,
                       Password = "123",
                       Phone = "099999999",
                       IsActive = true,
                       IsSupperAdmin= true
                   }
            );
            modelBuilder.Entity<RoleEntities>()
                .HasData(
                 new RoleEntities
                 {
                     CreatedAt = DateTime.Now,
                     UpdatedAt = DateTime.Now,
                     CreatedBy = 1,
                     Id = 1,
                     Name = "Administrator",
                     IsActive = true
                 },
                   new RoleEntities
                   {
                       CreatedAt = DateTime.Now,
                       UpdatedAt = DateTime.Now,
                       CreatedBy = 1,
                       Id = 2,
                       Name = "Manager",
                       IsActive = true
                   },
                   new RoleEntities
                   {
                       CreatedAt = DateTime.Now,
                       UpdatedAt = DateTime.Now,
                       CreatedBy = 1,
                       Id = 3,
                       Name = "Coordinator",
                       IsActive = true
                   },
                   new RoleEntities
                   {
                       CreatedAt = DateTime.Now,
                       UpdatedAt = DateTime.Now,
                       CreatedBy = 1,
                       Id = 4,
                       Name = "Student",
                       IsActive = true
                   },
                   new RoleEntities
                   {
                       CreatedAt = DateTime.Now,
                       UpdatedAt = DateTime.Now,
                       CreatedBy = 1,
                       Id = 5,
                       Name = "Guest",
                       IsActive = true
                   }
            );
            modelBuilder.Entity<UserRoleEntities>()
               .HasData(
                  new UserRoleEntities
                  {
                      CreatedAt = DateTime.Now,
                      Id = 1,
                      UserId = 1,
                      RoleId = 1,
                      IsActive = true,
                      CreatedBy = 1
                  }
           );
            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<UserEntities> Users { get; set; }
        public virtual DbSet<RoleEntities> Roles { get; set; }
        public virtual DbSet<UserRoleEntities> UserRoles { get; set; }
        public virtual DbSet<FacultyEntities> Facultys { get; set; }
        public virtual DbSet<DepartmentEntities> Departments { get; set; }
        public virtual DbSet<ContributionEntities> Contributions { get; set; }
        public virtual DbSet<ContributionCommentEntities> ContributionComments { get; set; }
    }
}
