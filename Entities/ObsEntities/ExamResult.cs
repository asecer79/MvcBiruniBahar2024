namespace Entities.ObsEntities
{
    public class ExamResult
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public decimal Grade { get; set; }
    }
}
