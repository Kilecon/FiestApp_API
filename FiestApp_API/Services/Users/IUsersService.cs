using FiestApp_API.Services.Base;
using FiestApp_Domain.Entities;
using FiestApp_Infrastructure.Documents;

namespace FiestApp_API.Services.Users;

public interface IUsersService : IService<UserDocument, UserEntity>
{
}
