using Microsoft.AspNet.Identity.EntityFramework;
using StudentManager.DomainModels;
using System.Data.Entity;

namespace StudentMAnager.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("Students", throwIfV1Schema: false)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<StudentClass> Classes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            var student = modelBuilder.Entity<Student>()
                .HasKey(x => x.Id)
                .HasMany<Course>(s => s.Courses)
                .WithMany(c => c.Students)
                .Map(cs =>
                {
                    cs.MapLeftKey("StudentRedId");
                    cs.MapRightKey("CourseRefId");
                    cs.ToTable("StudentCourse");
                });

            var professor = modelBuilder.Entity<Professor>()
                 .HasKey(x => x.Id)
                 .HasMany<Course>(s => s.Courses)
                 .WithMany(c => c.Professor)
                 .Map(cs =>
                 {
                     cs.MapLeftKey("ProfessorRedId");
                     cs.MapRightKey("CourseRefId");
                     cs.ToTable("ProfessorCourse");
                 });

            modelBuilder.Entity<Grade>().HasKey(g => g.GradeId);

            modelBuilder.Entity<Student>()
                .HasMany<Grade>(s => s.Grades)
                .WithOptional(s => s.Student)
                .HasForeignKey(s => s.StudentId);

            modelBuilder.Entity<Course>()
                .HasKey(c => c.CourseId)
                .HasMany<Grade>(c => c.Grades)
                .WithOptional(c => c.Course)
                .HasForeignKey(c => c.CourseId);

            modelBuilder.Entity<StudentClass>()
                .HasKey(c => c.ClassId)
                .HasMany<Student>(c => c.Students)
                .WithOptional(c => c.StudentClass)
                .HasForeignKey(c => c.StudentClassId);


            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}
