namespace PracticeTracker.Domain.PracticeSchedule;

public class PracticeScheduleDb
{
    public byte[] Id { get; set; }
    public byte[] PracticeId { get; set; }
    public byte[] GroupId { get; set; }
    public byte[] UserId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public Boolean IsRemoved { get; set; }

    public PracticeScheduleDb(){}
}