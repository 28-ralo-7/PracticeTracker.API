using System.Security.Claims;
using PracticeTracker.Domain.Role;
using PracticeTracker.Domain.Users;
using PracticeTracker.Services.Authorization.Interfaces;
using PracticeTracker.Services.Authorization.Validate;
using PracticeTracker.Services.Tools;

namespace PracticeTracker.Services.Authorization;

public class AuthorizationService : IAuthorizationService
{
    private readonly IAuthorizationRepository _authorizationRepository;

    public AuthorizationService(IAuthorizationRepository authorizationRepository)
    {
        _authorizationRepository = authorizationRepository;
    }

    public Response AuthorizeByLoginAndPassword(string login, string password)
    {
        Response response = new Response();

        String loginTrimmed = login.Trim();
        String passwordTrimmed = password.Trim();

        List<Error> errors = AuthValidator.Validate(loginTrimmed, passwordTrimmed);

        if (errors.Count != 0)
        {
            response.AddError(errors);
        }
        else
        {
            String passwordHash = PasswordTools.GetPasswordHash(passwordTrimmed);
            UserDB userDb = _authorizationRepository.GetByLoginAndPasswordHash(loginTrimmed, passwordHash);

            if (userDb.ID != null)
            {
                RoleDB role = _authorizationRepository.GetRoleById(userDb.RoleID);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, ByteArrayToString(userDb.ID)),
                    new Claim(ClaimTypes.Role, role.Type)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Cookie");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                response = Response.Success(claimsPrincipal);
            }
            else
            {
                response.AddError(new Error("Неверный логин или пароль"));
            }

        }

        return response;
    }

    public static String ByteArrayToString(Byte[] bytes)
    {
        String hex = BitConverter.ToString(bytes);
        return hex.Replace("-", "");
    }

}