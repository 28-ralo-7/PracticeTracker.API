using PracticeTracker.Domain.Group;
using PracticeTracker.Domain.PracticeSchedule;
using PracticeTracker.Services.Group.Interfaces;

namespace PracticeTracker.Services.Group;

public class GroupService : IGroupService
{
    public GroupDomain[] GetGroupByPermission(string userId)
    {
        PracticeScheduleDb[] practiceSchedules = _practiceScheduleService.GetByLeadId(userId);
    }
}