using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticeTracker.Services.Tools;
using IAuthorizationService = PracticeTracker.Services.Authorization.Interfaces.IAuthorizationService;

namespace PracticeTracker.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthorizationController : ControllerBase
{
    private IAuthorizationService _authorizationService;

    public AuthorizationController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    [HttpPost(Name = "Authorization")]
    public async Task<Response> Authorize(String login, String password)
    {
        Response response = _authorizationService.AuthorizeByLoginAndPassword(login, password);

        if (response.IsSuccess)
        {
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(response.Data));
    
            return new Response(null);
        }
        else
        {
            return response;
        }
    }
}