using QLyProject.Data;
using QLyProject.Models;
using QLyProject.Repositorys.IRepository;

namespace QLyProject.Repositorys
{
    public class TeacherRepository : Repository<Teacher> , ITeacherRepository
    {
        private readonly DataContext _dbContext;
        public TeacherRepository(DataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
