using PracticeTracker.Domain.Role;
using PracticeTracker.Domain.Users;

namespace PracticeTracker.Services.Authorization.Interfaces;

public interface IAuthorizationRepository
{
    UserDB GetByLoginAndPasswordHash(String login, String passwordHash);
    RoleDB GetRoleById(byte[] id);
}