using QLyProject.Data;
using QLyProject.Models;
using QLyProject.Repositorys.IRepository;

namespace QLyProject.Repositorys
{
    public class EnrollmentRepository : Repository<Enrollments> , IEnrollmentRepository
    {
        private readonly DataContext _dbContext;
        public EnrollmentRepository(DataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
