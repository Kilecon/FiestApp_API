using FiestApp_Infrastructure.Documents;
using FiestApp_Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FiestApp_Infrastructure.Repositories.UserRepository;

public class UserRepository : RepositoryBase<UserDocument>, IUserRepository
{
    public UserRepository(DbContext context, ILogger<UserRepository> logger) : base(context, logger)
    {
    }
}