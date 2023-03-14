namespace Web.API.Demo.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public bool IsMale { get; set; }
        public Subject Subject { get; set; }
        public ICollection<StudentTeacher> StudentTeachers { get; set; }
    }
}
