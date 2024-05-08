using Entities.CommonEntities;
using Entities.ObsEntities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.ObsDbContext.Ef.Repository
{
    public class BiruniSchoolDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = "server = .; database = BiruniSchoolDb; Trusted_Connection=True; TrustServerCertificate = True";

            optionsBuilder.UseSqlServer(connString);
        }

        public DbSet<Faculty>? Faculties { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Instructor>? Instructors { get; set; }
        public DbSet<Exam>? Exams { get; set; }
        public DbSet<ExamResult>? ExamResults { get; set; }
        public DbSet<StudentCourse>? StudentCourses { get; set; }
        public DbSet<InstructorCourse>? InstructorCourse { get; set; }

        public DbSet<User>? Users { get; set; }
        public DbSet<OperationClaim>? OperationClaims { get; set; }
        public DbSet<UserOperationClaim>? UserOperationClaims { get; set; }

    }
}
