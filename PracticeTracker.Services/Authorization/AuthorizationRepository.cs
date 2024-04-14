using PracticeTracker.Domain.Role;
using PracticeTracker.Domain.Users;
using PracticeTracker.Services.Authorization.Interfaces;
using PracticeTracker.Services.Tools;

namespace PracticeTracker.Services.Authorization;

public class AuthorizationRepository : NpgSqlRepository, IAuthorizationRepository
{
    public UserDB GetByLoginAndPasswordHash(String login, String passwordHash)
    {
        try
        {
            string command = $"SELECT * FROM us_users WHERE login = '{login}' AND passwordHash = '{passwordHash}'";
            UserDB userDb = Get<UserDB>(command);

            return userDb;
        }
        catch (Exception e)
        {
            Console.WriteLine(e); //TODO: add logger
            throw;
        }
    }

    public RoleDB GetRoleById(byte[] id)
    {
        try
        {
            string idString = ByteArrayToString(id);
            string command = $"SELECT * FROM us_role WHERE id = decode('{idString}', 'hex')";
            RoleDB role = Get<RoleDB>(command);

            return role;
        }
        catch (Exception e)
        {
            Console.WriteLine(e); //TODO: add logger
            throw;
        }
    }
    
    public static String ByteArrayToString(Byte[] bytes)
    {
        String hex = BitConverter.ToString(bytes);
        return hex.Replace("-", "");
    }

}