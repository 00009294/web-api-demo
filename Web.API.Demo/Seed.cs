using Web.API.Demo.DbContexts;
using Web.API.Demo.Models;

namespace Web.API.Demo
{
    public class Seed
    {
        private readonly AppDbContext appDbContext;
        public Seed(AppDbContext context)
        {
              appDbContext = context;
        }
        public void SeedAppDbContext()
        {
























            //if (!appDbContext.StudentSubjects.Any())
            //{
            //    var studentSubjects = new List<StudentSubject>()
            //    {
            //        new StudentSubject()
            //        {
            //            Student = new Student()
            //            {
            //                Name = "Ali",
            //                IsMale= true,
            //                StudentTeachers= new List<StudentTeacher>()
            //                {
            //                    new StudentTeacher{ Teacher = new Teacher() {Name="Subair", IsMale = true}}
            //                    //new StudentTeacher{ Teacher = new Teacher() {Name="Mufid", IsMale = false}},
            //                    //new StudentTeacher{ Teacher = new Teacher() {Name="Komil", IsMale = true}}

            //                },
                            
            //            },
            //            Subject= new Subject()
            //            {
            //                Name = "Business",
            //                IsCore= true
            //            },
            //            StudentId = 1,
            //            SubjectId = 1
            //        },
            //        new StudentSubject()
            //        {
            //            Student = new Student()
            //            {
            //                Name = "Gani",
            //                IsMale= true,
            //                StudentTeachers= new List<StudentTeacher>()
            //                {
            //                    new StudentTeacher{ Teacher = new Teacher() {Name="Oysha", IsMale = false}}
            //                }
            //            },
            //            Subject= new Subject()
            //            {
            //                Name = "Finance",
            //                IsCore= false
            //            },
            //            StudentId = 2,
            //            SubjectId = 2
            //        },
            //        new StudentSubject()
            //        {
            //            Student = new Student()
            //            {
            //                Name = "Saida",
            //                IsMale= false,
            //                StudentTeachers= new List<StudentTeacher>()
            //                {
            //                    new StudentTeacher{ Teacher = new Teacher() {Name="Bobur", IsMale = true}}
            //                }
            //            },
            //            Subject= new Subject()
            //            {
            //                Name = "Law",
            //                IsCore= true
            //            },
            //            StudentId = 3,
            //            SubjectId = 3
            //        }
            //    };
            //    appDbContext.StudentSubjects.AddRange(studentSubjects);
            //    appDbContext.SaveChanges();
            //}
        }
    }
}
