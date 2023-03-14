using Web.API.Demo.DbContexts;
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
    }
}
