using PracticeTracker.Services.Tools;

namespace PracticeTracker.Services.Authorization.Validate;

public class AuthValidator
{
    public static List<Error> Validate(String login, String password)
    {
        List<Error> errors = new List<Error>();

        if (login.Length == 0)
        {
            errors.Add(new Error("Введите логин"));
        }

        if (password.Length == 0)
        {
            errors.Add(new Error("Введите пароль"));
        }

        return errors;
    }
}