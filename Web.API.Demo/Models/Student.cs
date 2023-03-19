namespace Web.API.Demo.Models
{
    public class Student
    {
        public int Id { get; set; }  
        public string Name { get; set; } 
        public bool IsMale { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }
        public ICollection<StudentTeacher> StudentTeachers { get; set; }
            
    }
}
