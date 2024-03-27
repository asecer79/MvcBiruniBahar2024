namespace Entities.ObsEntities
{
    public class Exam
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public DateTime ExamDate { get; set; }

    }
}
