namespace Web.API.Demo.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public bool IsCore { get; set; }
        public ICollection<Teacher> Teachers { get; set; }  
        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
