using Web.API.Demo.Models;

namespace Web.API.Demo.Interfaces
{
    public interface IStudentRepository
    {
        ICollection<Student> GetAllStudent();
        bool CreateStudent(int teacherId, int subjectId, Student student);
        bool UpdateStudent(Student student);
        Student GetStudent(int id);
        Student GetByName(string name);
        ICollection<Student> GetByGender(bool isMale);
        ICollection<Student> GetStudentBySubject(int subjectId);
        ICollection<Student> GetStudentByTeachers(int teacherId);
        bool IsExist(int id);
        bool Save();
    }
}
