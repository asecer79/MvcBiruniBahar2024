namespace ObsWebUI.Models.Entities
{
    public class StudentCourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Year { get; set; }
        public string Semester { get; set; }
        public DateTime EnrollmentDate { get; set; }

    }
}
