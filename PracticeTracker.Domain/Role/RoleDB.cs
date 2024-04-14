namespace PracticeTracker.Domain.Role;

public class RoleDB
{
    public byte[] ID { get; set; }
    public String Type { get; set; }
    public Boolean IsRemoved { get; set; }

    public RoleDB(){}
}