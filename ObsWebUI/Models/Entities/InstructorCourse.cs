namespace ObsWebUI.Models.Entities
{
    public class InstructorCourse
    {
        public int Id { get; set; }
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public int DepartmentId { get; set; }
        public int Year { get; set; }
        public string Semester { get; set; }
        public DateTime EnrollmentDate { get; set; }

    }
}
