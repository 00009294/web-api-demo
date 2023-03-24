using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.API.Demo.Models
{
    public class Teacher
    {
        public int Id { get; set; } = default(int);
        public string Name { get; set; } = String.Empty;
        public bool IsMale { get; set; }
        public Subject Subject { get; set; } 
        public int SubjectId { get; set; }
        public ICollection<StudentTeacher> StudentTeachers { get; set; }
    }
}
