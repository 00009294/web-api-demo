using Web.API.Demo.Models;

namespace Web.API.Demo.Interfaces
{
    public interface ITeacherRepository
    {
        ICollection<Teacher> GetAllTeacher();
        bool CreateTeacher(Teacher teacher);
        Teacher GetTeacher(int id);
        Teacher GetByName (string name);
        Subject GetSubjectByTeacher(int teacherId);
        ICollection<Student> GetStudentByTeacher(int teacherId);
        ICollection<Teacher> GetByGender(bool isMale);
        bool IsExist(int id);
        bool Save();


    }
}
