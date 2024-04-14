namespace PracticeTracker.Domain.Users;

public class UserDB
{
    public byte[] ID { get; set; }
    public String Surname { get; set; }
    public String Name { get; set; }
    public String Patronomic { get; set; }
    public String Login { get; set; }
    public String PasswordHash { get; set; }
    public byte[] RoleID { get; set; }
    public Boolean IsRemoved { get; set; }

    public UserDB() { }

}