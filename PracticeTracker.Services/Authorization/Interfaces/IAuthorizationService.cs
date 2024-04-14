using PracticeTracker.Services.Tools;

namespace PracticeTracker.Services.Authorization.Interfaces;

public interface IAuthorizationService
{
    Response AuthorizeByLoginAndPassword(String login, String password);
}