using Web.API.Demo.Models;

namespace Web.API.Demo.Interfaces
{
    public interface ISubjectRepository
    {
        ICollection<Subject> GetAllSubject();
        Subject GetSubject(int id);
        Subject GetByName(string name);
        ICollection<Subject> GetByCore(bool IsCore);
        bool IsExist(int id);

    }
}
