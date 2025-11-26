namespace WebApplication1.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public DateTime Date { get; set; }
        public string Topic { get; set; }
        public string Status { get; set; }
    }
}
