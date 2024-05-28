using Microsoft.EntityFrameworkCore;
using QLyProject.Data;
using QLyProject.Models;
using QLyProject.Repositorys.IRepository;

namespace QLyProject.Repositorys
{
    public class CourseRepository : Repository<Courses>, ICourseRepository
    {

        private readonly DataContext _dbContext;
        public CourseRepository(DataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
