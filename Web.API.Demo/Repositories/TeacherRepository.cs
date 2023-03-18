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

        public Teacher GetTeacher(int id)
        {
            return _appDbContext.Teachers.Where(t => t.Id == id).FirstOrDefault();
        }

        public bool IsExist(int id)
        {
            return _appDbContext.Teachers.Where(t=>t.Id == id) != null;
        }
    }
}
