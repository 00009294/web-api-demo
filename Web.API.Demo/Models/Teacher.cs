using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Web.API.Demo.Models
{
    public class Teacher
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        //[Index(IsClustered = true)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[TableColumnAttribute(TableColumnType.CreatedAt)]
        public int Id { get; set; } 
        public string Name { get; set; } = String.Empty;
        public bool IsMale { get; set; }
        public Subject Subject { get; set; } 
        public int SubjectId { get; set; }
        public ICollection<StudentTeacher> StudentTeachers { get; set; }
    }
}
