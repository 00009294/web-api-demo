using Web.API.Demo.Models;

namespace Web.API.Demo.Interfaces
{
    public interface ITeacherRepository
    {
        ICollection<Teacher> GetAllTeacher();
        Teacher GetTeacher(int id);
        Teacher GetByName (string name);
        ICollection<Teacher> GetByGender(bool isMale);
        bool IsExist(int id);


    }
}
