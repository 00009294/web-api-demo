using Web.API.Demo.Models;

namespace Web.API.Demo.Interfaces
{
    public interface ISubjectRepository
    {
        ICollection<Subject> GetAllSubject();
        bool CreateSubject(Subject subject);
        bool UpdateSubject(Subject subject);
        Subject GetSubject(int id);
        Subject GetByName(string name);
        ICollection<Subject> GetByCore(bool IsCore);
        ICollection<Teacher> GetTeacherBySubject (int subjectId);
        ICollection<Subject> GetSubjectByStudent (int studentId);
        bool IsExist(int id);
        bool Save();

    }
}
