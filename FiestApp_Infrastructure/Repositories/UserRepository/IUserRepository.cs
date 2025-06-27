using FiestApp_Infrastructure.Documents;
using FiestApp_Infrastructure.Repositories.Base;

namespace FiestApp_Infrastructure.Repositories.UsersRepository;

public interface IUserRepository : IRepository<UserDocument>
{
}
