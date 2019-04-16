using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OES.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        public UserType UserType { get; set; }
        public int UserTypeId { get; set; }

        public string Address { get; set; }

        public int? BloodGroupId { get; set; }
        [ForeignKey("BloodGroupId")]
        public BloodGroup BloodGroup { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole: IdentityRole {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");

            modelBuilder.Entity<Exam>()
                .HasRequired(c => c.Course)
                .WithMany(e => e.Exams);

            modelBuilder.Entity<Exam>()
                .HasRequired(t => t.Teacher)
                .WithMany(e => e.Exams);

            modelBuilder.Entity<Question>()
                .HasRequired(e => e.Exam)
                .WithMany(q => q.Questions);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Exams)
                .WithMany(s => s.Students)
                .Map(se => {
                    se.MapLeftKey("StudentId");
                    se.MapRightKey("ExamId");
                    se.ToTable("Attend");
                });

            modelBuilder.Entity<Result>()
                .HasRequired(s => s.Student)
                .WithMany(r => r.Results);

            modelBuilder.Entity<Result>()
                .HasRequired(e => e.Exam)
                .WithMany(r => r.Results);

            modelBuilder.Entity<Query>()
                .HasRequired(e => e.Exam)
                .WithMany(q => q.Queries);

            modelBuilder.Entity<Query>()
                .HasRequired(s => s.Student)
                .WithMany(q => q.Queries);

            modelBuilder.Entity<Comment>()
                .HasRequired(q => q.Query)
                .WithMany(c => c.Comments);

            modelBuilder.Entity<Comment>()
                .HasRequired(c => c.CommentIt)
                .WithMany(c => c.Comments);

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(b => b.BloodGroup)
                .WithMany(u => u.ApplicationUsers);

            modelBuilder.Entity<Teacher>()
                .HasOptional(d => d.Designation)
                .WithMany(t => t.Teachers);
        }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}