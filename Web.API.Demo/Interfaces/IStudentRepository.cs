using Web.API.Demo.Models;

namespace Web.API.Demo.Interfaces
{
    public interface IStudentRepository
    {
        ICollection<Student> GetAllStudent();
        Student GetStudent(int id);
        Student GetByName(string name);
        ICollection<Student> GetByGender(bool isMale);
        bool IsExists(int id);
    }
}
