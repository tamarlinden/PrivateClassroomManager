namespace WebApplication1.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] Subjects { get; set; }
        public string Availability { get; set; }
        public string Status { get; set; }
    }
}
