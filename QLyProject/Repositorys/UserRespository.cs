using QLyProject.Data;
using QLyProject.Models;
using QLyProject.Repositorys.IRepository;

namespace QLyProject.Repositorys
{
    public class UserRespository: Repository<User> , IUserRepository
    {
        private readonly DataContext _dbContext;
        public UserRespository(DataContext dbContext) : base(dbContext)
            {
                _dbContext = dbContext;
            }
       
    }
}
