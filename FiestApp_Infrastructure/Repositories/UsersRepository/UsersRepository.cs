using FiestApp_Infrastructure.Documents;
using FiestApp_Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FiestApp_Infrastructure.Repositories.UsersRepository
{
    public class UsersRepository : RepositoryBase<UserDocument>, IRepository<UserDocument>
    {
        public UsersRepository(DbContext context) : base(context)
        {
        }
    }
}
