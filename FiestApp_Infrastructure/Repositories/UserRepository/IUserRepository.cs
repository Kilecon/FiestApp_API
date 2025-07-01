using FiestApp_Infrastructure.Documents;
using FiestApp_Infrastructure.Repositories.Base;

namespace FiestApp_Infrastructure.Repositories.UserRepository;

public interface IUserRepository : IRepository<UserDocument>
{
}
