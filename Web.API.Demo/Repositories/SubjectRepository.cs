using Web.API.Demo.DbContexts;
using Web.API.Demo.Interfaces;
using Web.API.Demo.Models;

namespace Web.API.Demo.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _appDbContext;
        public SubjectRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ICollection<Subject> GetAllSubject()
        {
            return _appDbContext.Subjects.OrderBy(s=>s.Id).ToList();
        }
        public Subject GetSubject(int id)
        {
            return _appDbContext.Subjects.Where(s => s.Id == id).FirstOrDefault();
        }
        public ICollection<Subject> GetByCore(bool IsCore)
        {
            return _appDbContext.Subjects.Where(s=>s.IsCore==IsCore).ToList();
        }

        public Subject GetByName(string name)
        {
            return _appDbContext.Subjects.Where(s => s.Name == name).FirstOrDefault();
        }

        public bool IsExist(int id)
        {
            return _appDbContext.Subjects.OrderBy(s => s.Id==id).Any();
        }


        public ICollection<Teacher> GetTeacherBySubject(int subjectId)
        {
            return _appDbContext.Teachers.Where(t=>t.Subject.Id==subjectId).ToList();
        }

        public ICollection<Subject> GetSubjectByStudent(int studentId)
        {
            return _appDbContext.StudentSubjects.Where(st => st.Student.Id == studentId).Select(st => st.Subject).ToList();
        }

        public bool CreateSubject(Subject subject)
        {
            _appDbContext.Subjects.Add(subject);
            return Save();
        }

        public bool Save()
        {
            return _appDbContext.SaveChanges() > 0 ? true : false;
        }
    }
}
