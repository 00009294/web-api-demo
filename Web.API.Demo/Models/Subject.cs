using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.API.Demo.Models
{
    public class Subject
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultValue("newid()")]
        public int Id { get; set; } 
        public string Name { get; set; } = String.Empty;
        public bool IsCore { get; set; }
        public ICollection<Teacher> Teachers { get; set; }  
       
        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
