using FiestApp_Infrastructure.Documents;
using FiestApp_Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FiestApp_Infrastructure.Repositories.UsersRepository
{
    public class UserRepository : RepositoryBase<UserDocument>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
