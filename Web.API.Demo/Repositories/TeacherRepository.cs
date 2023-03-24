using AutoMapper.Configuration.Annotations;
using Web.API.Demo.DbContexts;
using Web.API.Demo.Interfaces;
using Web.API.Demo.Models;

namespace Web.API.Demo.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _appDbContext;

        public TeacherRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool CreateTeacher(Teacher teacher)
        {
            //var teacherSubjectEntity = _appDbContext.Subjects.Where(s=>s.Id == subjectId).FirstOrDefault();
            //_appDbContext.Add(teacherSubjectEntity);

            //var teacherStudentEntity = _appDbContext.Students.Where(s=>s.Id== studentId).FirstOrDefault();
            //var student = new StudentTeacher()
            //{
            //    Student = teacherStudentEntity,
            //    Teacher = teacher

            //};
            //_appDbContext.Add(student);

            _appDbContext.Teachers.Add(teacher);
            return Save();
        }

        public bool DeleteTeacher(Teacher teacher)
        {
            _appDbContext.Remove(teacher);
            return Save();
        }

        public ICollection<Teacher> GetAllTeacher()
        {
            return _appDbContext.Teachers.ToList();
        }

        public ICollection<Teacher> GetByGender(bool isMale)
        {
            return _appDbContext.Teachers.Where(t=>t.IsMale== isMale).ToList();
        }

        public Teacher GetByName(string name)
        {
            return _appDbContext.Teachers.Where(t => t.Name == name).FirstOrDefault();
        }

        public ICollection<Student> GetStudentByTeacher(int teacherId)
        {
            return _appDbContext.StudentTeachers.Where(t=>t.Teacher.Id == teacherId).Select(s=>s.Student).ToList();
        }

        public Subject GetSubjectByTeacher(int teacherId)
        {
            return _appDbContext.Teachers.Where(t => t.Id == teacherId).Select(s=>s.Subject).FirstOrDefault();
        }

        public Teacher GetTeacher(int id)
        {
            return _appDbContext.Teachers.Where(t => t.Id == id).FirstOrDefault();
        }

        public bool IsExist(int id)
        {
            return _appDbContext.Teachers.Where(t=>t.Id == id) != null;
        }

        public bool Save()
        {
            return _appDbContext.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            _appDbContext.Add(teacher);
            return Save();
        }
    }
}
