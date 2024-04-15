using PracticeTracker.Domain.Group;

namespace PracticeTracker.Services.Group.Interfaces;

public interface IGroupService
{
    GroupDomain[] GetGroupByPermission(String userId);
}