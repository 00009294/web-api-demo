using Web.API.Demo.DbContexts;
using Web.API.Demo.Dto;
using Web.API.Demo.Interfaces;
using Web.API.Demo.Models;

namespace Web.API.Demo.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        private readonly AppDbContext _appDbContext;
        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ICollection<Student> GetAllStudent()
        {
            return _appDbContext.Students.OrderBy(p=>p.Id).ToList();
        }

        public ICollection<Student> GetByGender(bool isMale)
        {
            return _appDbContext.Students.Where(s=>s.IsMale==isMale).ToList();
            //throw new Exception();
        }

        public Student GetStudent(int id)
        {
            return _appDbContext.Students.Where(s => s.Id == id).FirstOrDefault();
        }

        public Student GetByName(string name)
        {
            return _appDbContext.Students.Where(s => s.Name == name).FirstOrDefault();
        }

        public bool IsExist(int id)
        {
            return _appDbContext.Students.Where(s=>s.Id == id).Any();
        }

        public bool CreateStudent(Student student)
        {
            return _appDbContext.Students.Add(student) != null;
        }

        public ICollection<Student> GetStudentBySubject(int subjectId)
        {
            return _appDbContext.StudentSubjects.Where(s=>s.Subject.Id == subjectId).Select(s=>s.Student).ToList();
        }

        public ICollection<Student> GetStudentByTeachers(int teacherId)
        {
            return _appDbContext.StudentTeachers.Where(t=>t.Teacher.Id == teacherId).Select(t=>t.Student).ToList();
        }
    }
}
