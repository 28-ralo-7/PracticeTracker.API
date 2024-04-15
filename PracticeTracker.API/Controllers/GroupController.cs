using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticeTracker.Domain.Group;
using PracticeTracker.Services.Group.Interfaces;

namespace PracticeTracker.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class GroupController : ControllerBase
{
    private readonly IGroupService _groupService;
    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }
    
    [Authorize(Roles = "Administrator")]
    [HttpGet]
    public GroupDomain[] ASd()
    {
        String userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;

        return _groupService.GetGroupByPermission(userId);
    }
}